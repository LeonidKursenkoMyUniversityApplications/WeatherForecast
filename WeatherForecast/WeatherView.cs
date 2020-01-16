using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using authorAttribute;
using WeatherForecast.Store;
using WeatherForecast.Event;
using WeatherForecast.Exception;
using System.ComponentModel.Composition;

namespace WeatherForecast
{
    [Author("Leonid Kursenko", version = 1.2)]
    [Export(typeof(UserControl))]
    [DisplayName("Weather")]
    public partial class WeatherView: UserControl
    {
        #region Atrributes
        private List<DayWeather> items;
        private List<ImagePath> resourcesPath;        
        #endregion

        #region Properties
        public List<DayWeather> Items
        {
            set
            {
                items = value;
                DataReceivedEventArgs args = new DataReceivedEventArgs();
                args.Message = MyStrings.InfoUpdated;
                OnDataReceived(args);

                if (items != null && items.Count > 0)
                {
                    SetDay(items[0]);
                    SetPeriodsList(items);
                }
            }

            get
            {
                return items;
            }
        }

        public List<ImagePath> ResourcesPath
        {
            set
            {
                resourcesPath = value;
                DataReceivedEventArgs args = new DataReceivedEventArgs();
                args.Message = MyStrings.InfoUpdated;
                OnDataReceived(args);
            }

            get
            {
                return resourcesPath;
            }
        }

        #endregion
                
        #region Constructors
        [ImportingConstructor]
        public WeatherView()
        {            
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void SetDay(DayWeather day)
        {
            if (day == null) throw new DayWeatherException(MyStrings.UndefinedDayValue, new NullReferenceException());
            dayTempLabel.Text = $"{MyStrings.Day}:{day.DayTemperature} C";
            nightTempLabel.Text = $"{MyStrings.Night}:{day.NightTemperature} C";
            SetWeather(day);
        }

        private void SetPeriodsList(List<DayWeather> days)
        {
            periodsListBox.Items.Clear();
            //if (days == null && days.Count > 0) return;
            if (days == null) throw new DayWeatherException(MyStrings.UndefinedList, new NullReferenceException());
            foreach (var d in days)
            {
                periodsListBox.Items.Add(d.Day);
            }
            periodsListBox.SelectedIndex = 0;
        }

        private void periodsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetDay(Items[periodsListBox.SelectedIndex]);
            } 
            catch(DayWeatherException ex)
            {
                throw new WeatherViewException(MyStrings.UnresolvedValue, ex);
            }
        }

        private void SetWeather(DayWeather d)
        {
            if (d == null) throw new DayWeatherException(MyStrings.UndefinedDayValue, new NullReferenceException());
            string path;
            try
            {
                path = resourcesPath.Find(resource => resource.Weather == d.Weather).Path;
            }
            catch(ImagePathException ex)
            {
                throw new DayWeatherException(MyStrings.UndefinedPathsList, ex);
            }
            try
            {
                weatherPictureBox.Image = Image.FromFile(path);
            }
            catch(DayWeatherException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new DayWeatherException(MyStrings.ErrorLoadImage + path, ex);
            }

        }

        #endregion

        #region Events
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        #endregion

        #region Handlers
        protected virtual void OnDataReceived(DataReceivedEventArgs e)
        {
            DataReceived?.Invoke(this, e);
        }
        #endregion

    }
}
