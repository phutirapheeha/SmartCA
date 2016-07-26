using System;
using System.Collections.Generic;
using SmartCA.Infrastructure.UI;
using System.ComponentModel;

namespace SmartCA.Presentation.ViewModels
{
    public abstract class AddressesViewModel : ViewModel
    {
        #region Constants

        private static class Constants
        {
            public const string AddressesPropertyName = "Addresses";
        }

        #endregion

        #region Private Fields

        private BindingList<MutableAddress> addresses;
        private DelegateCommand deleteAddressCommand;

        #endregion

        #region Constructors

        protected AddressesViewModel()
            : this(null)
        {
        }

        protected AddressesViewModel(IView view)
            : base(view)
        {
            this.addresses = new BindingList<MutableAddress>();
            this.deleteAddressCommand =
                new DelegateCommand(this.DeleteAddressCommandHandler);
        }

        #endregion

        #region Public Properties

        public BindingList<MutableAddress> Addresses
        {
            get { return this.addresses; }
        }

        public DelegateCommand DeleteAddressCommand
        {
            get { return this.deleteAddressCommand; }
        }

        #endregion

        #region Private Methods

        private void DeleteAddressCommandHandler(object sender,
            DelegateCommandEventArgs e)
        {
            MutableAddress address = e.Parameter as MutableAddress;
            if (address != null)
            {
                this.addresses.Remove(address);
            }
        }

        #endregion

        #region Virtual Methods

        protected virtual void PopulateAddresses()
        {
            this.OnPropertyChanged(Constants.AddressesPropertyName);
        }

        #endregion
    }
}
