using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace IndexER.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //TODO:Use variable below to set theme. Make a function/method for applying the theme.
        //private string _currentThemeName;

        public App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
