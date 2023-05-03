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

        private void ConvertToCelsius(object sender, RoutedEventArgs e)
        {
            var degreesFahrenheit = double.Parse(textBoxFahrenheit.Text);
            textBoxCelsius.Text = Math.Round(((degreesFahrenheit - 32) * 5 / 9),2).ToString();

        }

        private void ConvertToFahrenheit(object sender, RoutedEventArgs e)
        {
            var degreesCelsius = double.Parse(textBoxCelsius.Text);
            textBoxFahrenheit.Text = Math.Round(((degreesCelsius * 9 / 5) + 32),2).ToString();
        }
    }
}
