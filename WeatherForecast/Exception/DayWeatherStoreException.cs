using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Exception
{
    [Serializable]
    public class DayWeatherStoreException : WeatherViewException
    {
        public DayWeatherStoreException() { }
        public DayWeatherStoreException(string message) : base(message) { }
        public DayWeatherStoreException(string message, System.Exception inner) : base(message, inner) { }
        protected DayWeatherStoreException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
