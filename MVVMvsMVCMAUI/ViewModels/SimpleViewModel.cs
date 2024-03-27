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

        public SimpleViewModel()
        {
            DisplayCommand = new Command(OnDisplayCommand);
        }

        private void OnDisplayCommand(object obj)
        {
            App.Current.MainPage.DisplayAlert("Tu mensaje es:", Message, "OK");
        }
    }
}

