using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Threading;
using IndexER.Client.View;
using IndexER.Client.View.Controls;

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

        public void OpenTab(object typeParam)
        {
            //Open the tab on the main thread
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                var type = typeParam as Type;

                if (type == null) return;

                var header = new CustomTabItem();

                var instance = (TabControlBase)Activator.CreateInstance(type);

                OpenTab(header, instance);
            });
        }

        private void OpenTab(CustomTabItem header, TabControlBase instance)
        {
        //    if (!CanOpenNew(instance)) return;
        //
        //    if (!IsFeatureEnabled(instance.GetType()))
        //    {
        //        var notAvailableHeader = new CustomTabItem { Label = { Content = "Funktion ej tillgänglig" } };
        //
        //        var functionNotAvailable = new FunctionNotAvailable(GetFeatureName(instance.GetType()));
        //        DispatcherHelper.CheckBeginInvokeOnUI(() =>
        //        {
        //            var item = new TabItem
        //            {
        //                Header = notAvailableHeader,
        //                Content = functionNotAvailable
        //            };
        //
        //            functionNotAvailable.TabItem = item;
        //
        //            notAvailableHeader.CloseButton.Click += CloseButton_Click;
        //            functionNotAvailable.CloseRequested += instance_CloseRequested;
        //
        //            TabCollection.Add(item);
        //
        //
        //            item.Focus();
        //        });
        //
        //        return;
            }
        }
}
