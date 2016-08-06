using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using IndexER.Client.View;
using System.Linq;

namespace IndexER.Client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      // private void Button_Click(object sender, RoutedEventArgs e)
      // {
      //   //  About window = new About();
      //
      //    // window.Show();
      // }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Settings window = new Settings();

            window.Show();

        }
    }
}