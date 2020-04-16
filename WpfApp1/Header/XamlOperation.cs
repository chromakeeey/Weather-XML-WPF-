using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace WpfApp1.Header
{
    public static class XamlOperation
    {
        public static bool isCityDownloaded(int id)
        {
            string path = String.Format(@"{0}xmldata\{1}.xaml", AppDomain.CurrentDomain.BaseDirectory, id.ToString());
            return File.Exists(path);
        }

        public static bool isCityValid(int id)
        {
            string link = String.Format("http://informer.gismeteo.by/rss/{0}.xml", id);
            byte[] download_buffer = new WebClient().DownloadData(link);

            return (download_buffer.Length != 0);
        }

        public static List<WeatherData> readCity()
        {
            return new List<WeatherData>();
        }

        public static List<WeatherData> readGismeteoXML(int id)
        {
            int index = 0;

            string link;
            byte[] download_buffer;

            Stream stream;
            List<WeatherData> readData;

            link = String.Format("http://informer.gismeteo.by/rss/{0}.xml", id);
            download_buffer = new WebClient().DownloadData(link);

            stream = new MemoryStream(download_buffer);
            readData = new List<WeatherData>();

            XmlTextReader reader = new XmlTextReader(stream);

            while (reader.Read())
            {
                if (reader.IsStartElement("channel") && !reader.IsEmptyElement)
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement("item") && !reader.IsEmptyElement)
                        {
                            WeatherData weatherData = new WeatherData();

                            while (reader.Read())
                            {
                                if ( reader.IsStartElement("title") )
                                {
                                    weatherData.dateTime = (index == 1 || index == 3) ? DateTime.Now.AddDays(1) : DateTime.Now;
                                    weatherData.city = WeatherData.parseGismeteoCity(reader.ReadString());
                                }

                                else if ( reader.IsStartElement("description") )
                                {
                                    WeatherData tmpWeather = new WeatherData();
                                    tmpWeather = WeatherData.parseGismeteo(reader.ReadString());

                                    weatherData.state = tmpWeather.state;
                                    weatherData.temperature = tmpWeather.temperature;
                                    weatherData.wind = tmpWeather.wind;
                                    weatherData.windspeed = tmpWeather.windspeed;
                                    weatherData.preasure = tmpWeather.preasure;
                                }

                                else if ( !reader.IsStartElement() && reader.Name == "item" )
                                {
                                    readData.Add(weatherData);
                                    index++;

                                    break;
                                }
                            }
                        }
                        else if (!reader.IsStartElement() && reader.Name == "configuration") break;
                    }

                }
            }

            List<WeatherData> formatWeather = new List<WeatherData>();
            WeatherData formatData = new WeatherData();

            formatData.temperature = (readData[0].temperature + readData[1].temperature) / 2;
            formatData.windspeed = (readData[0].windspeed + readData[1].windspeed) / 2;
            formatData.preasure = (readData[0].preasure + readData[1].preasure) / 2;

            formatData.city = readData[0].city;
            formatData.dateTime = readData[0].dateTime;
            formatData.state = readData[0].state;
            formatData.wind = readData[0].wind;

            formatWeather.Add(formatData);
            formatData = new WeatherData();

            formatData.temperature = (readData[2].temperature + readData[2].temperature) / 2;
            formatData.windspeed = (readData[2].windspeed + readData[3].windspeed) / 2;
            formatData.preasure = (readData[2].preasure + readData[3].preasure) / 2;

            formatData.city = readData[2].city;
            formatData.dateTime = readData[2].dateTime;
            formatData.state = readData[2].state;
            formatData.wind = readData[2].wind;

            formatWeather.Add(formatData);

            return formatWeather;
        }

        public static City readXML(int id)
        {
            string path = String.Format(@"{0}xmldata\{1}.xaml", AppDomain.CurrentDomain.BaseDirectory, id.ToString());

            XmlSerializer xml = new XmlSerializer(typeof(City));

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (City)xml.Deserialize(fileStream);
            }
        }

        public static void writeXML(City city)
        {
            string path = String.Format(@"{0}xmldata\{1}.xaml", AppDomain.CurrentDomain.BaseDirectory, city.id.ToString());

            XmlSerializer xml = new XmlSerializer(typeof(City));
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xml.Serialize(fileStream, city);
            }
        }
    }
}
