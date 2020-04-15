using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace WpfApp1.Header
{
    public class WeatherData
    {
        public string city;

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
            MessageBox.Show(value);

            string pattern = @"температура \d..\d";
            string edit_value;

            Regex regex = new Regex(pattern);
            MatchCollection matchedAuthors = regex.Matches(value);

            if (matchedAuthors.Count != 0)
            {
                edit_value = matchedAuthors[0].Value;
                string number = string.Empty;
                int average = 0;

                for (int i = 0; i < edit_value.Length; i++)
                {
                    if (edit_value[i] == '.')
                    {
                        if (number.Length != 0)
                            average += Convert.ToInt32(number);

                        number = string.Empty;
                    }

                    if (Char.IsDigit(edit_value[i]))
                        number += edit_value[i];
                }

                weatherData.temperature = average / 2;
            }

            MessageBox.Show(weatherData.temperature.ToString());



            return weatherData;
        }
    }
}
