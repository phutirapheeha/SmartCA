using System;
using System.Collections.Generic;
using SmartCA.Infrastructure.UI;
using System.Windows.Data;
using SmartCA.Application;
using SmartCA.Model.Companies;
using SmartCA.Model.Projects;
using System.ComponentModel;
using SmartCA.Model.Contacts;
using SmartCA.Model;

namespace SmartCA.Presentation.ViewModels
{
    public class ProjectContactViewModel : AddressesViewModel
    {
        #region Constants

        private static class Constants
        {
            public const string CurrentContactPropertyName = "CurrentContact";
        }

        #endregion

        private CollectionView contacts;
        private IList<ProjectContact> contactsList;
        ProjectContact currentContact;
        private CollectionView companies;
        private DelegateCommand saveCommand;
        private DelegateCommand newCommand;

        #region Constructors

        public ProjectContactViewModel()
            : this(null)
        {
        }

        public ProjectContactViewModel(IView view)
            : base(view)
        {
            this.contactsList = UserSession.CurrentProject.Contacts;
            this.contacts = new CollectionView(contactsList);
            this.currentContact = null;
            this.companies = new CollectionView(CompanyService.GetAllCompanies());
            this.saveCommand = new DelegateCommand(this.SaveCommandHandler);
            this.newCommand = new DelegateCommand(this.NewCommandHandler);
        }

        #endregion

        public CollectionView Contacts
        {
            get { return this.contacts; }
        }

        public ProjectContact CurrentContact
        {
            get { return this.currentContact; }
            set
            {
                if (this.currentContact != value)
                {
                    this.currentContact = value;
                    this.OnPropertyChanged(Constants.CurrentContactPropertyName);
                    this.saveCommand.IsEnabled = (this.currentContact != null);
                    this.PopulateAddresses();
                }
            }
        }

        public CollectionView Companies
        {
            get { return this.companies; }
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
            this.currentContact.Contact.Addresses.Clear();
            foreach (MutableAddress address in this.Addresses)
            {
                this.currentContact.Contact.Addresses.Add(address.ToAddress());
            }
            ProjectService.SaveProjectContact(this.currentContact);
        }

        private void NewCommandHandler(object sender, EventArgs e)
        {
            ProjectContact contact = new ProjectContact(UserSession.CurrentProject,
                                         null, new Contact(null,
                                                   "{First Name}", "{Last Name}"));
            this.contactsList.Add(contact);
            this.contacts.Refresh();
            this.contacts.MoveCurrentToLast();
        }

        protected override void PopulateAddresses()
        {
            if (this.currentContact != null)
            {
                this.Addresses.Clear();
                foreach (Address address in this.currentContact.Contact.Addresses)
                {
                    this.Addresses.Add(new MutableAddress(address));
                }
                base.PopulateAddresses();
            }
        }
    }
}
