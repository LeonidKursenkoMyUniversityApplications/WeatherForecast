﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Exception
{
    [Serializable]
    public class DayWeatherException : WeatherViewException
    {
        public DayWeatherException() { }
        public DayWeatherException(string message) : base(message) { }
        public DayWeatherException(string message, System.Exception inner) : base(message, inner) { }
        protected DayWeatherException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

         
}
