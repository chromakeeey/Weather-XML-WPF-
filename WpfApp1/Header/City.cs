using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
