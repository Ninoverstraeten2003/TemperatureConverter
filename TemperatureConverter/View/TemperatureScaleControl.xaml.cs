using System.Windows;
using System.Windows.Controls;

namespace View
{
    public partial class TemperatureScaleControl : UserControl
    {
        public TemperatureScaleControl()
        {
            InitializeComponent();
        }

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); } 
            set { SetValue(HeaderProperty,value); } 
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string),
            typeof(TemperatureScaleControl), new PropertyMetadata(""));

        public double Value
        {
            get { return (double)GetValue(ValueProperty); } set { SetValue(ValueProperty,value);} }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double),
            typeof(TemperatureScaleControl),new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}