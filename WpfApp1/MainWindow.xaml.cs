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
using LiveCharts.Defaults;

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

        public void setCity(City city)
        {
            this.city = city;
            WeatherData weatherData = city.nowWeatherData();

            lbl_name.Text = city.name;
            lbl_state.Text = weatherData.state;
            lbl_temperature.Text = String.Format("{0} ‎℃", weatherData.temperature);
            lbl_wind.Text = weatherData.wind;
            lbl_windspeed.Text = String.Format("{0} м/с", weatherData.windspeed);
            lbl_preasure.Text = String.Format("{0} мм", weatherData.preasure);
            lbl_averagetmp.Text = city.averageTemperature().ToString();

            StatChart.AxisX[0].MinValue = double.NaN;
            StatChart.AxisX[0].MaxValue = double.NaN;
            StatChart.AxisY[0].MinValue = double.NaN;
            StatChart.AxisY[0].MaxValue = double.NaN;

            StatChart.Series.Clear();

            StatChart.Series = new SeriesCollection()
            {
                new LineSeries
                {
                    Values = city.valuesGet(),
                    PointGeometrySize = 15
                }
                
                
            };

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

        private void CityChange_Click(object sender, RoutedEventArgs e)
        {
            TakeCity takeCity = new TakeCity();

            takeCity.mainWindow = this;
            takeCity.ShowDialog();

            
        }
    }
}
