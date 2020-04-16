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

using WpfApp1.Header;

namespace WpfApp1.Dialog
{
    /// <summary>
    /// Interaction logic for AddCity.xaml
    /// </summary>
    public partial class AddCity : Window
    {
        public MainWindow mainWindow;

        public string Error
        {
            get { return fiel_id.Text; }

            set
            {
                errorTextBox.Visibility = Visibility.Visible;
                errorTextBox.Text = value;
            }
        }

        public AddCity()
        {
            InitializeComponent();
            

            errorTextBox.Visibility = Visibility.Hidden;
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void AddCity_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(fiel_id.Text))
            {
                Error = "Поле не заполнено.";
                return;
            }

            if (!int.TryParse(fiel_id.Text, out _))
            {
                Error = "Значение было введено неправильно.";
                return;
            }

            int id = Convert.ToInt32(fiel_id.Text);

            if (XamlOperation.isCityDownloaded(id))
            {
                Error = "Город уже существует.";
                return;
            }

            if (!XamlOperation.isCityValid(id))
            {
                Error = "Город не был найден.";
                return;
            }


            errorTextBox.Visibility = Visibility.Hidden;

            
            City city = new City();

            city.id = id;
            city.weatherDatas = XamlOperation.readGismeteoXML(id);
            city.name = city.weatherDatas[0].city;

            XamlOperation.writeXML(city);
            MessageBox.Show("Город был успешно добавлен.");

        }
    }
}
