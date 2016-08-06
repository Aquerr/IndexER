/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:IndexER.Client"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using IndexER.Client.Service;
using Microsoft.Practices.ServiceLocation;

namespace IndexER.Client.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
               // SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<ISettingViewModel, SettingsViewModel>();
                SimpleIoc.Default.Register<IAboutViewModel, AboutViewModel>();
                SimpleIoc.Default.Register<ITabNavigationService, TabNavigationService>();
                // Create run time view services and models
                //TODO:Insert here interfaces.
                // SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public static ITabNavigationService TabNavigationService { get { return SimpleIoc.Default.GetInstance<ITabNavigationService>(); } }

        public IAboutViewModel About {get { return SimpleIoc.Default.GetInstance<IAboutViewModel>(Guid.NewGuid().ToString()); }}
        public ISettingViewModel Settings {get { return SimpleIoc.Default.GetInstance<ISettingViewModel>(Guid.NewGuid().ToString()); } }
        public static MainViewModel Main {get { return SimpleIoc.Default.GetInstance<MainViewModel>(); } }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}