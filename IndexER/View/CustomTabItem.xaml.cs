﻿using System;
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

namespace IndexER.Client.View
{
    /// <summary>
    /// Interaction logic for CustomTabItem.xaml
    /// </summary>
    public partial class CustomTabItem : UserControl
    {
        public CustomTabItem()
        {
            InitializeComponent();
        }

        public void SetLabel(string label)
        {
            Label.Content = label;
        }
    }
}
