using System;
using System.Collections.Generic;
using SmartCA.Model.Projects;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Infrastructure;
using SmartCA.Model.Contacts;

namespace SmartCA.Model.Projects
{
    public static class ProjectService
    {
        private static IProjectRepository projectRepository;
        private static IContactRepository contactRepository;
        private static IUnitOfWork unitOfWork;

        static ProjectService()
        {
            ProjectService.unitOfWork = new UnitOfWork();
            ProjectService.projectRepository =
                RepositoryFactory.GetRepository<IProjectRepository,
                Project>(ProjectService.unitOfWork);
            ProjectService.contactRepository =
                RepositoryFactory.GetRepository<IContactRepository,
                Contact>(ProjectService.unitOfWork);
        }

        public static IList<Project> GetAllProjects()
        {
            return ProjectService.projectRepository.FindAll();
        }

        public static IList<MarketSegment> GetMarketSegments()
        {
            return ProjectService.projectRepository.FindAllMarketSegments();
        }

        public static void SaveProject(Project project)
        {
            ProjectService.projectRepository[project.Key] = project;
            ProjectService.unitOfWork.Commit();
        }

        public static void SaveProjectContact(ProjectContact contact)
        {
            ProjectService.contactRepository[contact.Contact.Key]
                = contact.Contact;
            // Add/Update the project contact
            ProjectService.projectRepository.SaveContact(contact);
            ProjectService.unitOfWork.Commit();
        }
    }
}
