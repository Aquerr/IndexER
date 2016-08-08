using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Threading;
using IndexER.Client.View;
using IndexER.Client.View.Controls;
using IndexER.Client.ViewModel;

namespace IndexER.Client.Service
{
    public class TabNavigationService : ITabNavigationService
    {
        private List<string> _allowFeatureList = new List<string>();
        private ObservableCollection<TabItem> _tabCollection;

        public TabNavigationService()
        {

        }

        public ObservableCollection<TabItem> TabCollection
        {
            get { return _tabCollection ?? (_tabCollection = new ObservableCollection<TabItem>()); }
        }

        public void ShowTab(TabControlBase control)
        {
            var header = new CustomTabItem();

            OpenTab(header, control);
        }

        public TabControlBase GetActiveTab()
        {
            foreach (var item in TabCollection)
            {
                if (item.IsSelected)
                    return item.Content as TabControlBase;
            }

            return null;
        }

        public void CloseAllTabs()
        {
            //Make a copy of the list
            var tabs = new List<TabItem>(TabCollection);
            foreach (var item in tabs)
                CloseTab(item);

       //     if (MainWindowOpen)
       //         OpenTab(typeof(MainWindow));
        }

        public void ForceCloseAllTabs()
        {
            //Make a copy of the list
            var tabs = new List<TabItem>(TabCollection);
            foreach (var item in tabs)
            {
                ForceCloseTab(item);
            }
        }

        public bool CanCloseAllTabs()
        {
            if (TabCollection.Count > 0) return true;
            return false;
        }

        private void instance_CloseRequested(object sender, TabControlBase.CloseRequestedEventArgs e)
        {
            var control = e.Control;
            DoClose(control);
        }

        private void DoClose(Control control)
        {
            foreach (var item in TabCollection)
            {
                if (!ReferenceEquals(item.Content, control)) continue;
                TabCollection.Remove(item);
                return;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var grid = btn.Parent as Grid;
            if (grid == null) return;

            var customTabItem = grid.Parent as CustomTabItem;

            if (customTabItem == null) return;

            var tabItem = customTabItem.Parent as TabItem;
            if (tabItem == null) return;

            CloseTab(tabItem);
        }

        private void CloseTab(TabItem item)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                var tcb = item.Content as TabControlBase;
                if (tcb == null) return;

                var viewModel = tcb.DataContext as TabControlViewModelBase;

                if (viewModel != null)
                    viewModel.CloseCommand.Execute(null);
            });
        }

        public void OpenTab(object typeParam)
        {
            //Open the tab on the main thread
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                var type = typeParam as Type;

                if (type == null) return;

                var header = new CustomTabItem();

                var instance = (TabControlBase) Activator.CreateInstance(type);

                OpenTab(header, instance);
            });
        }

        private void ForceCloseTab(TabItem item)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                var tcb = item.Content as TabControlBase;
                if (tcb != null)
                {
                    var viewModel = tcb.DataContext as TabControlViewModelBase;

                    if (viewModel != null)
                        viewModel.ForceCloseCommand.Execute(null);
                }
            });
        }

        private void OpenTab(CustomTabItem header, TabControlBase instance)
        {
            if (!CanOpenNew(instance)) return;
          
            if (!IsFeatureEnabled(instance.GetType()))
            {
                var notAvailableHeader = new CustomTabItem {Label = {Content = "Strona niedostępna"}};
          
                var functionNotAvailable = new FunctionNotAvailable(GetFeatureName(instance.GetType()));
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    var item = new TabItem
                    {
                        Header = notAvailableHeader,
                        Content = functionNotAvailable
                    };
          
                    functionNotAvailable.TabItem = item;
          
                    notAvailableHeader.CloseButton.Click += CloseButton_Click;
                    functionNotAvailable.CloseRequested += instance_CloseRequested;
          
                    TabCollection.Add(item);
          
          
                    item.Focus();
                });

                return;
            }

            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                var item = new TabItem
                {
                    Header = header,
                    Content = instance
                };

                instance.TabItem = item;

                header.CloseButton.Click += CloseButton_Click;
                instance.CloseRequested += instance_CloseRequested;

                if (instance is MainWindow)
                {
                  //  RemoveAllSaleHandlers();
                  //  header.CloseButton.Visibility = Visibility.Collapsed;
                  //
                  //  TabCollection.Insert(0, item);
                }
                else
                {
                    TabCollection.Add(item);
                }


                item.Focus();
            });
        }

        private bool CanOpenNew(object instance)
        {
            var tabControl = instance as TabControlBase;
            if (tabControl == null) return true;

            var tabControlViewModel = tabControl.DataContext as TabControlViewModelBase;
            if (tabControlViewModel == null || tabControlViewModel.AllowMultipleTabs) return true;

            foreach (var tabItem in TabCollection)
            {
                if (tabItem.Content.GetType() == instance.GetType())
                {
                    var item = tabItem;
                    DispatcherHelper.CheckBeginInvokeOnUI(() => { item.IsSelected = true; });
                    return false;
                }
            }

            return true;
        }

        private bool IsFeatureEnabled(Type instance)
        {
            var lastOrDefault = GetFeatureName(instance);

            if (lastOrDefault == null) return false;

            return IsFeatureEnabled(lastOrDefault);
        }

        private string GetFeatureName(Type instance)
        {
            var item = instance.ToString().Split('.');

            var lastOrDefault = item.LastOrDefault();
            return lastOrDefault;
        }

        private bool IsFeatureEnabled(string featureName)
        {
            switch (featureName)
            {
                //Standard features
           //     case "MainWindow":
                case "About":
                case "Settings":
                case "ClassMenu":
                    return true;

                default:
                    return true;
                    //throw new ArgumentOutOfRangeException(string.Format("The feature {0} is undefined.", featureName));
            }
        }
    }
}
