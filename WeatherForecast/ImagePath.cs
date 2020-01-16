using authorAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    [Author("Leonid Kursenko", version = 1.1)]
    public class ImagePath
    {
        public Weather Weather { set; get; }
        public string Path { set; get; }
    }
}
