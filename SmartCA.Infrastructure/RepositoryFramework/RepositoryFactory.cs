﻿using System;
using System.Collections.Generic;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.RepositoryFramework.Configuration;
using System.Configuration;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public static class RepositoryFactory
    {
        // Dictionary to enforce the singleton pattern
        private static Dictionary<string, object> repositories = new Dictionary<string, object>();

        /// <summary>
        /// Gets or creates an instance of the requested interface.  Once a 
        /// repository is created and initialized, it is cached, and all 
        /// future requests for the repository will come from the cache.
        /// </summary>
        /// <typeparam name="TRepository">The interface of the repository 
        /// to create.</typeparam>
        /// <typeparam name="TEntity">The type of the EntityBase that the 
        /// repository is for.</typeparam>
        /// <param name="unitOfWork">The unit of work that the repository 
        /// will be participating in.</param>
        /// <returns>An instance of the interface requested.</returns>
        public static TRepository GetRepository<TRepository, TEntity>(IUnitOfWork unitOfWork)
            where TRepository : class, IRepository<TEntity>
            where TEntity : EntityBase
        {
            // Initialize the provider's default value
            TRepository repository = default(TRepository);

            string interfaceShortName = typeof(TRepository).Name;

            // See if the provider was already created and is in the cache
            if (!RepositoryFactory.repositories.ContainsKey(interfaceShortName))
            {
                // Not there, so create it

                // Get the repositoryMappingsConfiguration config section
                RepositorySettings settings = (RepositorySettings)ConfigurationManager.GetSection(RepositoryMappingConstants.RepositoryMappingsConfigurationSectionName);

                // Get the type to be created
                Type repositoryType = Type.GetType(settings.RepositoryMappings[interfaceShortName].RepositoryFullTypeName);

                // See if an IUnitOfWork needs to be injected to the repository's constructor
                object[] constructorArgs = null;

                // Check if an IUnitOfWork was passed in and if the repository 
                // type to be created derives from RepositoryBase<T>
                if (unitOfWork != null &&
                    repositoryType.IsSubclassOf(typeof(RepositoryBase<TEntity>)))
                {
                    constructorArgs = new object[] { unitOfWork };
                }

                // Create the repository, and cast it to the interface specified
                repository = Activator.CreateInstance(repositoryType, constructorArgs) as TRepository;

                // Add the new provider instance to the cache
                RepositoryFactory.repositories.Add(interfaceShortName, repository);
            }
            else
            {
                // The provider was in the cache, so retrieve it
                repository = (TRepository)RepositoryFactory.repositories[interfaceShortName];
            }
            return repository;
        }

        /// <summary>
        /// Gets or creates an instance of the requested interface.  Once a 
        /// repository is created and initialized, it is cached, and all 
        /// future requests for the repository will come from the cache.
        /// </summary>
        /// <typeparam name="TRepository">The interface of the repository 
        /// to create.</typeparam>
        /// <typeparam name="TEntity">The type of the EntityBase that the 
        /// repository is for.</typeparam>
        /// <returns>An instance of the interface requested.</returns>
        public static TRepository GetRepository<TRepository, TEntity>()
            where TRepository : class, IRepository<TEntity>
            where TEntity : EntityBase
        {
            return RepositoryFactory.GetRepository<TRepository, TEntity>(null);
        }
    }
}
