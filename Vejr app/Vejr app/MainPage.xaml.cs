using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Vejr_app
{
    public partial class MainPage : ContentPage
    {
        const string APPID = "d7cd476294a7bde93961c7f0506e0635";
        string CityName = "Colombo";
        public MainPage()
        {
            InitializeComponent();
            getWeather("Viborg");//one day weather
            getForcast("Viborg");
        }

        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6", city, APPID);

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<VejrInfo.root>(json);

                VejrInfo.root output = result;

                Viborg.Text = string.Format("{0}", output.name);
                Land.Text = string.Format("{0}", output.sys.Country);
                Grader.Text = string.Format("{0} \u00b0" + "C", output.main.Temp);
            }
        }
        void getForcast(string city)
        {
            int day = 5;
            string url = string.Format("https://api.openweathermap.org/data/2.5/onecall?lat=56.438993&lon=9.350895&exclude=current,minutely,hourly&appid=d7cd476294a7bde93961c7f0506e0635&units=metric&cnt=6", city, day, APPID);
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);
                var Obejct = JsonConvert.DeserializeObject<weatherForcast>(json);

                weatherForcast.root forcast = Obejct;

                //Dag 1

                Dag.Text = string.Format("{0}", weatherForcast.root.dt );

                Fugtighed.Text = string.Format("{0}", liste.main); // weather Condition
                Beskrivelse.Text = string.Format("{0}", weather[0].descrition); // weather Description
                Tempratur.Text = string.Format("{0}\u00b0" + "C", temp.day); // weather Temp
                Vind.Text = string.Format("{0} km/h", daily.speed); // weather Wind Speed

                //Dag 2

                Dag2.Text = string.Format("{0}", GetDate(forcast.liste.dt).DayOfWeek); //returning Day

                Fugtighed2.Text = string.Format("{0}", forcast.List[1].weather[0].main); // weather Condition
                Beskrivelse2.Text = string.Format("{0}", forcast.List[1].weather[0].descrition); // weather Description
                Tempratur2.Text = string.Format("{0}\u00b0" + "C", forcast.List[1].temp.day); // weather Temp
                Vind2.Text = string.Format("{0} km/h", forcast.List[1].speed); // weather Wind Speed
            }

        }
       

        DateTime GetDate(double milliseconds)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(milliseconds).ToLocalTime();

            return day;
        }

    }
}
