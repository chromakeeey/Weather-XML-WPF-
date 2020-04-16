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
using System.IO;
using WpfApp1.Header;

namespace WpfApp1.Dialog
{
    /// <summary>
    /// Interaction logic for TakeCity.xaml
    /// </summary>
    public partial class TakeCity : Window
    {
        public MainWindow mainWindow;

        public TakeCity()
        {
            InitializeComponent();

            errorTextBox.Visibility = Visibility.Hidden;

            comboCityID = new List<int>();
            readDirectory();
        }

        private string Error
        {
            get { return errorTextBox.Text; }

            set
            {
                errorTextBox.Text = value;
                errorTextBox.Visibility = Visibility.Visible;
            }
        }

        private List<int> comboCityID;

        private void readDirectory()
        {
            comboCityID.Clear();

            string directory = String.Format(@"{0}xmldata\", AppDomain.CurrentDomain.BaseDirectory);
            string[] path = Directory.GetFiles(directory);

            for (int i = 0; i < path.Length; i++)
            {
                string extension = System.IO.Path.GetExtension(path[i]);

                if (extension == ".xaml")
                {
                    string filename = System.IO.Path.GetFileNameWithoutExtension(path[i]);

                    if (int.TryParse(filename, out _))
                    {
                        int id = Convert.ToInt32(filename);
                        City city = new City();

                        city = XamlOperation.readXML(id);

                        comboCityID.Add(id);
                        cb_ID.Items.Add(city.name + " (" + id.ToString() + ")");
                    }

                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void TakeCity_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cb_ID.Text))
            {
                Error = "Вы ничего не выбрали";
                return;
            }

            City city = XamlOperation.readXML(comboCityID[cb_ID.SelectedIndex]);
            city.checkWeatherUpdate();

            mainWindow.setCity(city);
            Hide();
        }
    }
}
