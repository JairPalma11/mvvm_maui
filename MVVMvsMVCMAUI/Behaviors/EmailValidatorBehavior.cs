using System;
using System.Text.RegularExpressions;

namespace MVVMvsMVCMAUI.Behaviors
{
	/// <summary>
	/// T: es el tipo de control XAML
	/// al cual queremos aplicar el behavior
	/// nos dara acceso a sus propiedades
	/// en los metodos, sin embargo,
	/// Este behavior solo podra ser usado en Entry
	/// de otra forma lanzara una excepcion.
	/// </summary>
	public class EmailValidatorBehavior : Behavior<Entry>
	{
		/// <summary>
		/// Se ejecuta cuando se agrega el behavior
		/// al control XAML deseado en este caso un Entry
		/// </summary>
		/// <param name="bindable"></param>
        protected override void OnAttachedTo(Entry bindable)
        {
            //nos sucribimos al evento que esta
            //escuchando cuando escribimos en el Entry
            bindable.TextChanged += OnTextChanged;
        }

        /// <summary>
        /// Este evento es el que estara escuchando
        /// por los cambios que se hagan en el texto y
        /// permite validar si es correcto el email o no
        /// Cambiando el color.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object? sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            var isEmailValid = IsValidEmail(e.NewTextValue);
            if (isEmailValid)
            {
                entry.BackgroundColor = Colors.Transparent;
            }
            else
            {
                entry.BackgroundColor = Colors.OrangeRed;
            }
        }

        /// <summary>
        /// Se ejecuta cuando se remueve el behavior
        /// al control XAML deseado en este caso un Entry
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnDetachingFrom(Entry bindable)
        {
            //removemos la suscripcion
            //para liberar y limpiar memoria
            //cuando se elimine el behavior de nuestro
            //control Entry
            bindable.TextChanged -= OnTextChanged;
        }

        /// <summary>
        /// Valida el texto si es un Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}

