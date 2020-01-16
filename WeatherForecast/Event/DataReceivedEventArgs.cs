using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Event
{
    public class DataReceivedEventArgs : EventArgs
    {
        public string Message { set; get; }
    }
}
