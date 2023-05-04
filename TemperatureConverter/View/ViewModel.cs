using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    internal class ConverterViewModel
    {
        public ConverterViewModel() { }
        private double temperatureInKelvin;
        public event PropertyChangedEventHandler PropertyChanged;
        public double TemperatureInKelvin
        {
            get { return temperatureInKelvin; }
            set
            {
                temperatureInKelvin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TemperatureInKelvin)));
            }
        }
    }
}
