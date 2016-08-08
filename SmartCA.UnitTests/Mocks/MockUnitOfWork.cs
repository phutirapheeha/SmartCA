using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCA.Infrastructure;
using System.Diagnostics;
using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.RepositoryFramework;

namespace SmartCA.UnitTests
{
    public class MockUnitOfWork : IUnitOfWork
    {
        private Dictionary<EntityBase, IUnitOfWorkRepository> addedEntities;

        public MockUnitOfWork()
        {
            this.addedEntities = new Dictionary<EntityBase, IUnitOfWorkRepository>();
        }

        #region IUnitOfWork Members

        public void RegisterAdded(EntityBase entity, IUnitOfWorkRepository repository)
        {
            Debug.WriteLine("RegisterAdded called...");
            this.addedEntities.Add(entity, repository);
        }

        public void RegisterChanged(EntityBase entity, IUnitOfWorkRepository repository)
        {
            Debug.WriteLine("RegisterChanged called...");
        }

        public void RegisterRemoved(EntityBase entity, IUnitOfWorkRepository repository)
        {
            Debug.WriteLine("RegisterRemoved called...");
        }

        public void Commit()
        {
            Debug.WriteLine("Commit called...");
            Debug.WriteLine("Committing the following added entities:  ");
            foreach (EntityBase entity in this.addedEntities.Keys)
            {
                Debug.WriteLine(string.Format("Entity Key:  {0}  Associated Repository Type:  {1}",
                    entity.Key.ToString(), this.addedEntities[entity].ToString()));
                this.addedEntities[entity].PersistNewItem(entity);
            }
        }

        #endregion
    }
}
