using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Exception
{
    [Serializable]
    public class ImagePathException : WeatherViewException
    {
        public ImagePathException() { }
        public ImagePathException(string message) : base(message) { }
        public ImagePathException(string message, System.Exception inner) : base(message, inner) { }
        protected ImagePathException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
