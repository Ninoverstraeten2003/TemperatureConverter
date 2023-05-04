using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    internal class KelvinTemperatureScale:ITemperatureScale
    {   
        public string Name { get;  }
        public double ConvertToKelvin(double temperature)
        {
            return 0.0;
        }
        public double ConvertFromKelvin(double temperature)
        {
            return temperature;
        }
    }
}
