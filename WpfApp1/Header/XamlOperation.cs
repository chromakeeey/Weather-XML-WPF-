using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows;
using System.Xml;

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
                                

                                if (reader.IsStartElement("title")) MessageBox.Show(reader.ReadString());
                                else
                                if (reader.IsStartElement("description")) WeatherData.parseGismeteo(reader.ReadString());
                                else
                                if (!reader.IsStartElement() && reader.Name == "item")
                                {
                                    
                                    break;
                                }
                            }
                        }
                        else if (!reader.IsStartElement() && reader.Name == "configuration") break;
                    }

                }
            }

        
            return new List<WeatherData>();
        }

        
    }
}
