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

namespace WheatherObserver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WheatherStation station = new WheatherStation();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenWindow_Click(object sender, RoutedEventArgs e)
        {
            WheaterWindow window = new WheaterWindow(new WheatherStateObserver (station));
            window.Show();
        }
    }
}
