using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMvsMVCMAUI.ViewModels
{
    /// <summary>
    /// Esta clase es solo un helper
    /// que permite refactorizar y reutilizar
    /// la implementacion de INotifyPropertyChanged
    /// para cada view model y no repetir codigo.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// este metodo encapsula lo que normalmente se haria
        /// con cada propiedad del view model
        /// ahorrando y reutilizando codigo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldValue">Valor anterior de la propiedad</param>
        /// <param name="newValue">Valor nuevo de la propiedad</param>
        /// <param name="propertyName">Nombre de la propiedad que propagara los cambios</param>
        /// <returns>True: si hubo actualizacion y notificacion del evento</returns>
        protected bool SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            //el decorator CallerMemberName
            //en tiempo de ejecucion obtiene el nombre de la proiedad
            //donde se ejecuta este metodo.
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                oldValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

