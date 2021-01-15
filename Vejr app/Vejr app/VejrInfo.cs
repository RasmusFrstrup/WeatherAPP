using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejr_app
{
    class VejrInfo
    {
        public class coord
        {

            public double lon { get; set; }
            public double lat { get; set; }

        }//end of cord class

        public class weather
        {
            public int ID { get; set; }
            public string Main { get; set; }
            public string Desc { get; set; }
        }//end of weather class

        public class main
        {
            public double Temp { get; set; }
            public double Pressure { get; set; }
            public double Humidty { get; set; }
        }//end of main class

        public class wind
        {
            public double speed { get; set; }

        }//end of wind class

        public class Sys
        {
            public string Country { get; set; }

        }//end of Sys class

        public class root
        {
            public string name { get; set; }
            public Sys sys { get; set; }
            public double dt { get; set; }
            public wind wind { get; set; }
            public main main { get; set; }
            public List<weather> weatherList { get; set; }
            public coord cordinate { get; set; }
        }
    }
}
