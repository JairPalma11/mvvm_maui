using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMvsMVCMAUI.ViewModels
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        private string? _message;

        public string? Message
        {
            get => _message;
            set
            {
                //verificamos que el valor actual
                //no sea el mismo
                if (_message != value)
                {
                    //para poder actulizar los datos
                    //unicamente cuando el valor sea diferente
                    _message = value;
                    //PropertyChanged(this, new PropertyChangedEventArgs("Message"));
                    //una vez asignado el nuevo valor
                    //necesitamos notificar a la vista del cambio
                    //atraves del evento PropertyChangedEventHandler
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand DisplayCommand { get; private set; }

        public ICommand UpdateCommand { get; private set; }

        public SimpleViewModel()
        {
            UpdateCommand = new Command(OnUpdateCommand);
            DisplayCommand = new Command(OnDisplayCommand);
        }

        private void OnUpdateCommand()
        {
            Message = "Se actulizo desde ViewModel";
        }

        private void OnDisplayCommand()
        {
            App.Current.MainPage.DisplayAlert("Tu mensaje es:", Message, "OK");
        }
    }
}

