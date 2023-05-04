using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TempConverter
{
    internal class TemperatureConverter
    {
        public TemperatureConverter() { }
  
        public class CelsiusConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var kelvin = (double)value;
                var celsius = kelvin - 273.15;

                return celsius.ToString();
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var celsius = double.Parse((string)value);
                var kelvin = celsius + 273.15;

                return kelvin;
            }
        }
        public class FahrenheitConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var kelvin = (double)value;
                var celsius = kelvin - 273.15;
                var fahrenheit = celsius * 1.8 + 32;

                return fahrenheit.ToString();
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var fahrenheit = double.Parse((string)value);
                var celsius = (fahrenheit - 32) / 1.8;
                var kelvin = celsius + 273.15;

                return kelvin;
            }
        }
    }
}
