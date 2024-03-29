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
using System.Windows.Shapes;

namespace WheatherObserver
{
    /// <summary>
    /// Interaction logic for WheaterWindow.xaml
    /// </summary>
    public partial class WheaterWindow : Window
    {
        WheatherStateObserver wheatherStateObserver;

        public WheaterWindow (WheatherStateObserver wheatherObserver)
        {
            InitializeComponent();
            this.wheatherStateObserver = wheatherObserver;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = wheatherStateObserver;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            wheatherStateObserver.Dispose();
        }
    }
}
