using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IndexER.Interfaces.ViewModels;

namespace IndexER.Client.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings
    {
        public Settings()
        {
            DataContextChanged += SettingsHandler_DataContextChanged;
            InitializeComponent();
        }

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void SettingsHandler_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            await ((ISettingViewModel)DataContext).LoadAsync();
        }
    }
}
