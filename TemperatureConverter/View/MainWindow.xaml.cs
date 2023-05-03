using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertCelsius(object sender, RoutedEventArgs e)
        {
            var degreesCelsius = double.Parse(textBoxCelsius.Text);
            textBoxFahrenheit.Text = Math.Round((degreesCelsius * 9 / 5) + 32, 2).ToString();
            textBoxKelvin.Text = Math.Round(degreesCelsius + 273.15 , 2).ToString();
        }

        private void ConvertFahrenHeit(object sender, RoutedEventArgs e)
        {
            var degreesFahrenheit = double.Parse(textBoxFahrenheit.Text);
            textBoxCelsius.Text = Math.Round((degreesFahrenheit - 32) * 5 / 9, 2).ToString();
            textBoxKelvin.Text = Math.Round(((degreesFahrenheit - 32) * 5 / 9) + 273.15, 2).ToString();
        }

        private void ConvertKelvin(object sender, RoutedEventArgs e)
        {
            var degreesKelvin = double.Parse(textBoxKelvin.Text);
            textBoxCelsius.Text = Math.Round(degreesKelvin - 273.15).ToString();
            textBoxFahrenheit.Text = Math.Round((degreesKelvin - 273.15) * 9 / 5 + 32, 2).ToString();    

        }
    }
    
}
