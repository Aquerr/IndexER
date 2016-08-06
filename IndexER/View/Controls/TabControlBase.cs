using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using IndexER.Client.ViewModel;

namespace IndexER.Client.View.Controls
{
    public abstract class TabControlBase : UserControl
    {
        private TabItem _tabItem;

        protected TabControlBase()
        {
            DataContextChanged += MyTabControl_DataContextChanged;
        }

        private void MyTabControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = DataContext as TabControlViewModelBase;
            if (viewModel != null)
            {
                viewModel.CloseRequested += TabControlBase_CloseRequested;

                viewModel.TabTitleChangedEvent += viewModel_TabTitleChangedEvent;

                SetHeaderTitle();
            }

            Focus();
        }

        private void SetHeaderTitle()
        {
            var viewModel = DataContext as TabControlViewModelBase;
            if (viewModel == null) return;
            if (_tabItem == null) return;
            var header = _tabItem.Header as CustomTabItem;

            if (header != null)
                header.SetLabel(viewModel.TabTitle);
        }

        void viewModel_TabTitleChangedEvent(object sender, EventArgs e)
        {
            SetHeaderTitle();
        }

        private void TabControlBase_CloseRequested(object sender, EventArgs e)
        {
            InvokeCloseRequested();
        }

        public event EventHandler<CloseRequestedEventArgs> CloseRequested;

        private void InvokeCloseRequested()
        {
            var handler = CloseRequested;
            if (handler != null) handler(this, new CloseRequestedEventArgs(this));
        }

        public class CloseRequestedEventArgs : EventArgs
        {
            public CloseRequestedEventArgs(Control control)
            {
                Control = control;
            }
            public Control Control { get; private set; }
        }

        public TabItem TabItem
        {
            get { return _tabItem; }
            set
            {
                _tabItem = value;
                InvokeTabItemChangedEvent();
            }
        }

        public event EventHandler<EventArgs> TabItemChangedEvent;

        protected virtual void InvokeTabItemChangedEvent()
        {
            SetHeaderTitle();
            var handler = TabItemChangedEvent;
            if (handler != null) handler(this, EventArgs.Empty);
        }

       // public int? SelectedUserId
       // {
       //     get
       //     {
       //         var tabControlViewModelBase = DataContext as TabControlViewModelBase;
       //         return tabControlViewModelBase != null ? tabControlViewModelBase.SelectedUserId : null;
       //     }
       // }
    }
}
