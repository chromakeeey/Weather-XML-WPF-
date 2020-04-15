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
using LiveCharts;
using LiveCharts.Wpf;

using WpfApp1.Header;
using WpfApp1.Dialog;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public City city = new City();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TestClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void addCity_Click(object sender, RoutedEventArgs e)
        {
            AddCity addCity = new AddCity();

            addCity.mainWindow = this;
            addCity.ShowDialog();
        }
    }
}
