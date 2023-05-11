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
            this.Increment = new AddCommand(this.Temperature, 1,0,999);
            this.Decrement = new AddCommand(this.Temperature, -1,1,1000);
        }
        public string Name => temperatureScale.Name;
        public Cell<double> Temperature { get; }
        public ICommand Increment { get; }
        public ICommand Decrement { get; }
    }

    public class AddCommand : ICommand
    {
        private readonly Cell<double> _cell;
        private int _delta;
        private int _minimum;
        private int _maximum;

        public AddCommand(Cell<double> cell, int delta, int minimum, int maximum)
        {
            this._cell = cell;
            this._delta = delta;
            this._minimum = minimum;
            this._maximum = maximum;
            this._cell.PropertyChanged += (sender,e) => CanExecuteChanged(this,new EventArgs());
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _cell.Value >= this._minimum && _cell.Value <= this._maximum;
        }

        public void Execute(object parameter)
        {
            _cell.Value = Math.Round(_cell.Value + _delta);
        }
    }
}
