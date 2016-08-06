using System;
using System.Windows;
using GalaSoft.MvvmLight;
using IndexER.Client.Commands;
using IndexER.Client.Service;
using IndexER.Client.View.Controls;

namespace IndexER.Client.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class MainViewModel : ViewModelBase
    {

        private readonly ITabNavigationService _tabNavigationService;

        public MainViewModel(ITabNavigationService tabNavigationService)
        {
            _tabNavigationService = tabNavigationService;

            SetupCommands();

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public RelayCommand OpenTabCommand { get; set; }
        //    public ICommand ExitCommand { get; set; }

        public bool IsLoggedIn
        {
            get { return true; }
        }

        public ITabNavigationService TabNavigationService
        {
            get { return _tabNavigationService; }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private void SetupCommands()
        {
            Func<TabControlBase> activeControl = _tabNavigationService.GetActiveTab;

            //TODO: Revisit

            //To make easier to read code

            OpenTabCommand = new RelayCommand(_tabNavigationService.OpenTab, param => IsLoggedIn);
        }
    }
}