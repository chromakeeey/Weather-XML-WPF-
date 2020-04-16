using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;


namespace WpfApp1.Header
{
    public class WeatherData
    {
        public string city;
        public DateTime dateTime;

        public string state;
        public float temperature;
        public string wind;
        public float windspeed;
        public float preasure;

        public WeatherData()
        {
            temperature = 0;
            wind = " ";
            state = "Неопределенно";
            windspeed = 0;
            preasure = 0;
        }

        public static WeatherData parseGismeteo(string value)
        {
            WeatherData weatherData = new WeatherData();

            string pattern = @"\D+";
            string[] numbers = Regex.Split(value, pattern);

            weatherData.temperature = (Convert.ToInt32(numbers[1]) + Convert.ToInt32(numbers[2])) / 2;
            weatherData.preasure = (Convert.ToInt32(numbers[3]) + Convert.ToInt32(numbers[4])) / 2;
            weatherData.windspeed = Convert.ToSingle(numbers[4]);

            weatherData.state = parseState(value);
            weatherData.wind = parseWind(value);

            return weatherData;
        }

        private static string parseState(string value)
        {
            string[] word = value.Split(',');

            if (word[0][0] == 'т')
                return "Неопределенно";

            return word[0];
        }
        
        private static string parseWind(string value)
        {
            string pattern = @"ветер \S+";
            MatchCollection collection = Regex.Matches(value, pattern);

            string field = collection[0].Value;
            string[] fields = field.Split(' ');
            fields[1] = fields[1].Remove(fields[1].Length - 1);

            return fields[1];
        }

        public static string parseGismeteoCity(string value)
        {
            string format = string.Empty;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == ':')
                {
                    format = value.Remove(i); 
                    break;
                }
            }

            return format;
        }

        public Image weatherImage()
        {
            Image image = new Image();
            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();

            switch (state)
            {
                case "Пасмурно": break;
                case "Малооблачно": break;
                case "Переменная облачность": break;
                case "Солнечно": bitmap.UriSource = new Uri("sun.png", UriKind.Relative); break;
                case "Облачно": break;
                case "Неопределенно": break;
                case "Пасмурно, дождь": break;

                default: break;
            }

            bitmap.EndInit();
            image.Source = bitmap;

            return image;
        }
    }
}
