using System.Collections.ObjectModel;
using System.Windows.Controls;
using IndexER.Client.View.Controls;

namespace IndexER.Client.Service
{
    public interface ITabNavigationService
    {
        ObservableCollection<TabItem> TabCollection { get; }
        void OpenTab(object typeParam);
        void CloseAllTabs();
        bool CanCloseAllTabs();
        void ForceCloseAllTabs();
        void ShowTab(TabControlBase control);
        TabControlBase GetActiveTab();
    }
}