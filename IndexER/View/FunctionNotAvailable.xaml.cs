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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IndexER.Client.ViewModel;

namespace IndexER.Client.View
{
    /// <summary>
    /// Interaction logic for FunctionNotAvailable.xaml
    /// </summary>
    public partial class FunctionNotAvailable
    {
        private readonly string _functionName;

        public FunctionNotAvailable(string functionName)
        {
            _functionName = functionName;
            InitializeComponent();

            var viewModel = (FunctionNotAvailableViewModel) DataContext;
            if(viewModel == null) return;

            viewModel.FunctionName = _functionName;
        }
    }
}
