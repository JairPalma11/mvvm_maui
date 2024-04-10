using System;
using System.Windows.Input;

namespace MVVMvsMVCMAUI.ViewModels
{
	public class BMICalculatorViewModel : BaseViewModel
	{
        /// <summary>
        /// Metros
        /// </summary>
        private double _height;
        public double Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        /// <summary>
        /// Kilogramos
        /// </summary>
        private double _mass;
        public double Mass
        {
            get => _mass;
            set => SetProperty(ref _mass, value);
        }

        /// <summary>
        /// Resultado del IMC
        /// índice de masa corporal. 
        /// </summary>
        private double _result;
        public double Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        /// <summary>
        /// calcula la formula
        /// </summary>
        public ICommand CalculateCommand { get; private set; }

        public BMICalculatorViewModel()
        {
            CalculateCommand = new Command(OnCalculateCommand);
        }

        private void OnCalculateCommand()
        {
            //nos saltamos validaciones
            //y vamos directo al calculo.
            //redondeamos
            var result = Math.Round(Mass / double.Pow(Height, 2), 2);
            Result = result;
        }
    }
}

