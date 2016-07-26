using System;
using System.ComponentModel;

namespace SmartCA.Infrastructure.UI
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private IView view;
        private DelegateCommand cancelCommand;
        private ObjectState currentObjectState;
        private const string currentObjectStatePropertyName = "CurrentObjectState";

        protected ViewModel()
            : this(null)
        {
        }

        protected ViewModel(IView view)
        {
            this.view = view;
            this.cancelCommand = new DelegateCommand(this.CancelCommandHandler);
            this.currentObjectState = ObjectState.Existing;
        }

        public enum ObjectState
        {
            New,
            Existing,
            Deleted
        }

        public DelegateCommand CancelCommand
        {
            get { return this.cancelCommand; }
        }

        public ObjectState CurrentObjectState
        {
            get { return this.currentObjectState; }
            set
            {
                if (this.currentObjectState != value)
                {
                    this.currentObjectState = value;
                    this.OnPropertyChanged(
                        ViewModel.currentObjectStatePropertyName);
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void CancelCommandHandler(object sender, EventArgs e)
        {
            this.CloseView();
        }

        protected void CloseView()
        {
            if (this.view != null)
            {
                this.view.Close();
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
