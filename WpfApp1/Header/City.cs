using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace WpfApp1.Header
{
    public class City
    {
        public int id;
        public string name;

        public List<WeatherData> weatherDatas;

        public City()
        {
            weatherDatas = new List<WeatherData>();
        }

        public WeatherData nowWeatherData()
        {
            if (weatherDatas.Count == 0)
                return new WeatherData();

            WeatherData weatherData = new WeatherData();
            DateTime dateTime = weatherDatas[0].dateTime;

            foreach (WeatherData item in weatherDatas)
            {
                if (item.dateTime > dateTime)
                {
                    dateTime = item.dateTime;
                    weatherData = item;
                }
            }

            return weatherData;
        }

        public ChartValues<ObservableValue> valuesGet()
        {
            ChartValues<ObservableValue> values = new ChartValues<ObservableValue>();

            foreach(var item in weatherDatas)
            {
                values.Add(new ObservableValue(item.temperature));
            }

            return values;
        }

        public float averageTemperature()
        {
            float value = 0;

            foreach(var item in weatherDatas)
            {
                value += item.temperature;
            }

            return value / weatherDatas.Count;
        }

        public void checkWeatherUpdate()
        {
            List<WeatherData> wData = XamlOperation.readGismeteoXML(id);
            bool valid = false;

            foreach (var item in wData)
            {
                if (!isWeatherValid(item.dateTime))
                {
                    weatherDatas.Add(item);
                    valid = true;
                }
            }

            if (valid)
                XamlOperation.writeXML(this);
        } 

        private bool isWeatherValid(DateTime time)
        {
            bool valid = false;

            foreach (var item in weatherDatas)
            {
                if (time.Year == item.dateTime.Year &&
                    time.Month == item.dateTime.Month &&
                    time.Day == item.dateTime.Day)
                {
                    valid = true;

                    break;
                }
            }

            return valid;
        }
    }
}
