using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexER.Client.Service;

namespace IndexER.Client.ViewModel
{
    public class AboutViewModel : TabControlViewModelBase, IAboutViewModel
    {
        public AboutViewModel(ITabNavigationService tabNavigationService)
        {
            _tabNavigationService = tabNavigationService;
        }

        private bool _refreshing;
        private readonly ITabNavigationService _tabNavigationService;

        public override string TabTitle { get { return "About"; } }
        public override bool AllowMultipleTabs { get { return false; } }

        public bool PanelLoading { get { return _refreshing; } }

        public bool Refreshing
        {
            get { return _refreshing; }
            set
            {
                if (_refreshing != value)
                {
                    _refreshing = value;
                    OnPropertyChanged("PanelLoading");
                }
            }
        }

        public override async Task RefreshAsync()
        {
            try
            {
               // await LoadAsync();
            }
            finally
            {
               // Refreshing = false;
            }
        }

        public override bool CanRefresh()
        {
            return true;
        }

        public async Task LoadAsync()
        {
            
        }
    }

}
