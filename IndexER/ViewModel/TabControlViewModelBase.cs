using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;
using IndexER.Client.Commands;

namespace IndexER.Client.ViewModel
{
    public abstract class TabControlViewModelBase : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _cancelCommand;
        private ICommand _closeCommand;
        private ICommand _okeyCommand;
        private ICommand _forceCloseCommand;
        private string _tabTitle;

        public new event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<EventArgs> CloseRequested;
        public event EventHandler<EventArgs> TabTitleChangedEvent;

        protected void InvokeCloseRequested()
        {
            var handler = CloseRequested;
            if(handler != null) handler(this,EventArgs.Empty);
        }

        public virtual bool AllowMultipleTabs { get { return true; } }

        public abstract Task RefreshAsync();
        public abstract bool CanRefresh();

        public virtual ICommand OkCommand { get { return _okeyCommand ?? (_okeyCommand = new RelayCommand(param => Ok(), param => CanOk())); } }
        public virtual ICommand CloseCommand { get { return _closeCommand ?? (_closeCommand = new RelayCommand(param => Close(), param => true)); } }
        public virtual ICommand ForceCloseCommand { get { return _forceCloseCommand ?? (_forceCloseCommand = new RelayCommand(param => ForceClose(), param => true)); } }
        public virtual ICommand CancelCommand { get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(param => Cancel(), param => CanCancel())); } }
        public virtual string TabTitle { get { return _tabTitle; } set { _tabTitle = value; InvokeTabTitleChangedEvent(); } }

        protected virtual void ForceClose()
        {
            InvokeCloseRequested();
        }

        protected virtual void Close()
        {
            InvokeCloseRequested();
        }

        protected virtual bool CanCancel()
        {
            return true;
        }

        protected virtual async Task Cancel()
        {
            Close();
        }

        protected virtual bool CanOk()
        {
            return true;
        }

        protected virtual async Task Ok()
        {
            Close();
        }

       // [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void InvokeTabTitleChangedEvent()
        {
            var handler = TabTitleChangedEvent;
            if (handler != null) handler(this, EventArgs.Empty);
        }


    }
}
