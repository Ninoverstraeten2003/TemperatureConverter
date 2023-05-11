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
            this.Increment = new AddCommand(this.Temperature, 1);
            this.Decrement = new AddCommand(this.Temperature, -1);
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

        public AddCommand(Cell<double> cell, int delta)
        {
            this._cell = cell;
            this._delta = delta;
            CanExecuteChanged += () => CanExecute();
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _cell.Value > -1 || _cell.Value < 1001;
        }

        public void Execute(object parameter)
        {
            _cell.Value = Math.Round(_cell.Value + _delta);
            CanExecuteChanged.Invoke(this, new CanExecuteChangedEventArgs(nameof(CanExecute)));
        }
    }
}
