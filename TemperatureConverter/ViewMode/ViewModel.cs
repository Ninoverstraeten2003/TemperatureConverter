using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cell;
using Model;

namespace ViewModel
{
    public class ConverterViewModel
    {
        public ConverterViewModel()
        {
            this.TemperatureInKelvin = new Cell<double>();

            this.Kelvin = new TemperatureScaleViewModel(this, new KelvinTemperatureScale());
            this.Celsius = new TemperatureScaleViewModel(this, new CelsiusTemperatureScale());
            this.Fahrenheit = new TemperatureScaleViewModel(this, new FahrenheitTemperatureScale());
        }

        public Cell<double> TemperatureInKelvin { get; }

        public TemperatureScaleViewModel Kelvin { get; }

        public TemperatureScaleViewModel Celsius { get; }

        public TemperatureScaleViewModel Fahrenheit { get; }

        public IEnumerable<TemperatureScaleViewModel> Scales
        {
            get
            {
                yield return Celsius;
                yield return Fahrenheit;
                yield return Kelvin;
            }
        }
    }

    public class TemperatureScaleViewModel
    {
        private readonly ConverterViewModel parent;

        private readonly ITemperatureScale temperatureScale;

        public TemperatureScaleViewModel(ConverterViewModel parent, ITemperatureScale temperatureScale)
        {
            this.parent = parent;
            this.temperatureScale = temperatureScale;
            this.Temperature = this.parent.TemperatureInKelvin.Derive(kelvin => temperatureScale.ConvertFromKelvin(kelvin), celsius => temperatureScale.ConvertToKelvin(celsius));
            double minimum = this.temperatureScale.ConvertFromKelvin(0);
            double maximum = this.temperatureScale.ConvertFromKelvin(1000);
            this.Increment = new AddCommand(this.Temperature, 1,minimum,maximum);
            this.Decrement = new AddCommand(this.Temperature, -1,minimum,maximum);
        }
        public string Name => temperatureScale.Name;
        public Cell<double> Temperature { get; }
        public ICommand Increment { get; }
        public ICommand Decrement { get; }
    }

    public class AddCommand : ICommand
    {
        private readonly Cell<double> _cell;
        private readonly double _delta;
        private readonly double _minimum;
        private readonly double _maximum;

        public AddCommand(Cell<double> cell, double delta, double minimum, double maximum)
        {
            this._cell = cell;
            this._delta = delta;
            this._minimum = minimum;
            this._maximum = maximum;
            this._cell.PropertyChanged += (sender, args) => CanExecuteChanged(this, new EventArgs());
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var newValue = _cell.Value + _delta;
            return this._minimum <= newValue && newValue <= this._maximum;
           
        }

        public void Execute(object parameter)
        {
            _cell.Value = Math.Round(_cell.Value + _delta);
        }
    }
}
