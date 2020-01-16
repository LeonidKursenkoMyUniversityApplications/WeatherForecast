using authorAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Exception;

namespace WeatherForecast.Store
{
    [Author("Leonid Kursenko", version = 1.0)]
    public class DayWeatherStore
    {
        #region Atrributes
        //private List<DayWeather> days;
        #endregion

        #region Properties
        public List<DayWeather> Days { set; get; }
        #endregion

        #region Constructors
        public DayWeatherStore()
        {
            Days = new List<DayWeather>();
        }
        #endregion

        #region Methods
        public List<DayWeather> Filter(Func<DayWeather, bool> f)
        {
            if (Days == null || Days.Count == 0)
                throw new DayWeatherStoreException(MyStrings.EmptyList);
            List<DayWeather> list = new List<DayWeather>();
            foreach (var day in Days)
            {
                if(f(day) == true)
                {
                    list.Add(day);
                }
            }
            return list;
        }

        public List<DayWeather> Sort<T>(Func<DayWeather, T> f)
        {
            if (Days == null || Days.Count == 0)
                throw new DayWeatherStoreException(MyStrings.EmptyList);
            return Days.OrderBy(f).ToList();
        }

        #endregion
    }
}
