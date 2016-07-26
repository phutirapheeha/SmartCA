using System;
using SmartCA.Infrastructure.UI;
using System.Windows.Data;
using SmartCA.Model.Companies;
using System.Collections.Generic;
using SmartCA.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Xceed.Wpf.DataGrid;

namespace SmartCA.Presentation.ViewModels
{
    public class CompanyViewModel : AddressesViewModel
    {
        #region Constants

        private static class Constants
        {
            public const string CurrentCompanyPropertyName = "CurrentCompany";
            public const string HeadquartersAddressPropertyName =
                "HeadquartersAddress";
        }

        #endregion

        #region Private Fields

        private CollectionView companies;
        private IList<Company> companiesList;
        private Company currentCompany;
        private MutableAddress headquartersAddress;
        private BindingList<MutableAddress> addresses;
        private DelegateCommand saveCommand;
        private DelegateCommand newCommand;

        #endregion

        #region Constructors

        public CompanyViewModel()
            : this(null)
        {
        }

        public CompanyViewModel(IView view)
            : base(view)
        {
            this.companiesList = CompanyService.GetAllCompanies();
            this.companies = new CollectionView(companiesList);
            this.currentCompany = null;
            this.addresses = new BindingList<MutableAddress>();
            this.headquartersAddress = null;
            this.saveCommand = new DelegateCommand(this.SaveCommandHandler);
            this.saveCommand.IsEnabled = false;
            this.newCommand = new DelegateCommand(this.NewCommandHandler);
        }

        #endregion

        #region Public Properties

        public CollectionView Companies
        {
            get { return this.companies; }
        }

        public Company CurrentCompany
        {
            get { return this.currentCompany; }
            set
            {
                if (this.currentCompany != value)
                {
                    this.currentCompany = value;
                    this.OnPropertyChanged(Constants.CurrentCompanyPropertyName);
                    this.saveCommand.IsEnabled = (this.currentCompany != null);
                    this.PopulateAddresses();
                    this.HeadquartersAddress =
                        new MutableAddress(
                            this.currentCompany.HeadquartersAddress);
                }
            }
        }

        public MutableAddress HeadquartersAddress
        {
            get { return this.headquartersAddress; }
            set
            {
                if (this.headquartersAddress != value)
                {
                    this.headquartersAddress = value;
                    this.OnPropertyChanged(
                        Constants.HeadquartersAddressPropertyName);
                }
            }
        }

        public DelegateCommand NewCommand
        {
            get { return this.newCommand; }
        }

        public DelegateCommand SaveCommand
        {
            get { return this.saveCommand; }
        }

        #endregion

        #region Private Methods

        private void SaveCommandHandler(object sender, EventArgs e)
        {
            this.currentCompany.Addresses.Clear();
            foreach (MutableAddress address in this.Addresses)
            {
                this.currentCompany.Addresses.Add(address.ToAddress());
            }
            this.currentCompany.HeadquartersAddress =
                this.headquartersAddress.ToAddress();
            CompanyService.SaveCompany(this.currentCompany);
        }

        private void NewCommandHandler(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Name = "{Enter Company Name}";
            this.companiesList.Add(company);
            this.companies.Refresh();
            this.companies.MoveCurrentToLast();
        }

        protected override void PopulateAddresses()
        {
            if (this.currentCompany != null)
            {
                this.Addresses.Clear();
                foreach (Address address in this.currentCompany.Addresses)
                {
                    this.Addresses.Add(new MutableAddress(address));
                }
                base.PopulateAddresses();
            }
        }

        #endregion
    }
}
