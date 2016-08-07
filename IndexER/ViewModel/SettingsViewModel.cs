using IndexER.Client.Service;
using IndexER.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexER.Database;
using IndexER.Logic;
using IndexER.Logic.Entities;

namespace IndexER.Client.ViewModel
{
    class SettingsViewModel : TabControlViewModelBase, ISettingViewModel
    {
        public SettingsViewModel(ITabNavigationService tabNavigationService)
        {
            _tabNavigationService = tabNavigationService;
            _classLogic = new ClassLogic();
        }

        private bool _refreshing;
        private readonly ITabNavigationService _tabNavigationService;
        private ObservableCollection<Class> _classes;
        private ClassLogic _classLogic;

        public override string TabTitle { get { return "Ustawienia"; } }
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

        //TODO:Move this code to ClassListViewModel.

      //  public async Task LoadAsync()
      //  {
      //     // ClassLogic logic = new ClassLogic();
      //     // var classlist = await logic.GetClassesAsync();
      //
      //      var classlist = await _classLogic.GetClassesAsync();
      //      ObservableCollection<Class> list = new ObservableCollection<Class>(classlist);
      //      Classes = list;
      //
      //  }
      //
      //  public ObservableCollection<Class> Classes
      //  {
      //      get { return _classes; }
      //      set
      //      {
      //          _classes = value;
      //          OnPropertyChanged();
      //      }
      //  }
    }
}
