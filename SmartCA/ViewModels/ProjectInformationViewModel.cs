using System;
using SmartCA.Presentation.Views;
using SmartCA.Model.Projects;
using SmartCA.Application;
using System.Windows.Data;
using SmartCA.Infrastructure.UI;
using System.ComponentModel;
using SmartCA.Model.Employees;
using SmartCA.Model.Companies;
using SmartCA.Infrastructure;
namespace SmartCA.Presentation.ViewModels
{
    public class ProjectInformationViewModel : ViewModel
    {
        private static class Constants
        {
            public const string CurrentProjectPropertyName = "CurrentProject";
            public const string ProjectAddressPropertyName = "ProjectAddress";
            public const string OwnerHeadquartersAddressPropertyName =
                "ProjectOwnerHeadquartersAddress";
        }

        private Project currentProject;
        private string newProjectNumber;
        private string newProjectName;
        private MutableAddress projectAddress;
        private MutableAddress projectOwnerHeadquartersAddress;
        private CollectionView owners;
        private CollectionView marketSegments;
        private CollectionView constructionAdministrators;
        private CollectionView principals;
        private DelegateCommand saveCommand;
        private DelegateCommand newCommand;

        public ProjectInformationViewModel()
            : this(null)
        {
        }

        public ProjectInformationViewModel(IView view)
            : base(view)
        {
            this.currentProject = UserSession.CurrentProject;
            this.newProjectNumber = string.Empty;
            this.newProjectName = string.Empty;

            this.projectAddress = new MutableAddress
            {
                Street = this.currentProject.Address.Street,
                City = this.currentProject.Address.City,
                State = this.currentProject.Address.State,
                PostalCode = this.currentProject.Address.PostalCode
            };

            this.projectOwnerHeadquartersAddress = new MutableAddress
            {
                Street = this.currentProject.Owner.HeadquartersAddress.Street,
                City = this.currentProject.Owner.HeadquartersAddress.City,
                State = this.currentProject.Owner.HeadquartersAddress.State,
                PostalCode =
                this.currentProject.Owner.HeadquartersAddress.PostalCode
            };

            this.CurrentObjectState =
                (this.currentProject != null ?
                ObjectState.Existing : ObjectState.New);

            this.owners = new CollectionView(CompanyService.GetOwners());

            this.marketSegments =
                new CollectionView(ProjectService.GetMarketSegments());

            this.constructionAdministrators =
                new CollectionView(
                    EmployeeService.GetConstructionAdministrators());

            this.principals = new CollectionView(EmployeeService.GetPrincipals());
            this.saveCommand = new DelegateCommand(this.SaveCommandHandler);
            this.newCommand = new DelegateCommand(this.NewCommandHandler);
        }

        public Project CurrentProject
        {
            get { return this.currentProject; }
        }

        public string NewProjectNumber
        {
            get { return this.newProjectNumber; }
            set
            {
                if (this.newProjectNumber != value)
                {
                    this.newProjectNumber = value;
                    this.VerifyNewProject();
                }
            }
        }

        public string NewProjectName
        {
            get { return this.newProjectName; }
            set
            {
                if (this.newProjectName != value)
                {
                    this.newProjectName = value;
                    this.VerifyNewProject();
                }
            }
        }

        public MutableAddress ProjectAddress
        {
            get { return this.projectAddress; }
        }

        public MutableAddress ProjectOwnerHeadquartersAddress
        {
            get { return this.projectOwnerHeadquartersAddress; }
        }

        public CollectionView Owners
        {
            get { return this.owners; }
        }

        public CollectionView MarketSegments
        {
            get { return this.marketSegments; }
        }

        public CollectionView ConstructionAdministrators
        {
            get { return this.constructionAdministrators; }
        }

        public CollectionView Principals
        {
            get { return this.principals; }
        }

        public DelegateCommand SaveCommand
        {
            get { return this.saveCommand; }
        }

        public DelegateCommand NewCommand
        {
            get { return this.newCommand; }
        }

        private void SaveCommandHandler(object sender, EventArgs e)
        {
            this.currentProject.Address = this.projectAddress.ToAddress();

            this.currentProject.Owner.HeadquartersAddress =
                this.projectOwnerHeadquartersAddress.ToAddress();

            ProjectService.SaveProject(this.currentProject);

            this.OnPropertyChanged(
                Constants.CurrentProjectPropertyName);

            this.CurrentObjectState = ObjectState.Existing;
        }

        private void NewCommandHandler(object sender, EventArgs e)
        {
            this.currentProject = null;
            this.projectAddress = new MutableAddress();

            this.OnPropertyChanged(
                Constants.ProjectAddressPropertyName);

            this.newProjectNumber = string.Empty;
            this.newProjectName = string.Empty;
            this.projectOwnerHeadquartersAddress = new MutableAddress();

            this.OnPropertyChanged(
                Constants.OwnerHeadquartersAddressPropertyName);

            this.CurrentObjectState = ObjectState.New;

            this.OnPropertyChanged(
                Constants.CurrentProjectPropertyName);
        }

        private void VerifyNewProject()
        {
            if (this.newProjectNumber.Length > 0 &&
                this.newProjectName.Length > 0)
            {
                this.currentProject = new Project(this.newProjectNumber,
                                          this.newProjectName);
                this.OnPropertyChanged(
                    Constants.CurrentProjectPropertyName);
            }
        }
    }
}
