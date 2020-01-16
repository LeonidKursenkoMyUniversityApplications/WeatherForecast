using authorAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    [Author("Leonid Kursenko", version = 1.1)]
    public class DayWeather
    {
        #region Properties
        public DateTime Day { set; get; }
        public double DayTemperature { set; get; }
        public double NightTemperature { set; get; }
        public Weather Weather { set; get; }        
        #endregion
    }
    
    public enum Weather { Sunny, Cloudy, Rainy}
}
