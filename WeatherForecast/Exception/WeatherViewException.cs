using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WeatherForecast.Exception
{
    [Serializable]
    public class WeatherViewException : System.Exception
    {
        public WeatherViewException() { }
        public WeatherViewException(string message) : base(message) { }
        public WeatherViewException(string message, System.Exception inner) : base(message, inner) { }
        protected WeatherViewException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    
}
