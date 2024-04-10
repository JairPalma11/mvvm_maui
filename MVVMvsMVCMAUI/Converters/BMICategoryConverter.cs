using System;
using System.Globalization;

namespace MVVMvsMVCMAUI.Converters
{
    public class BMICategoryConverter : IValueConverter
    {
        /// <summary>
        /// Se invoca este metodo cuando la informacion
        /// se mueve del Source hacia el Target
        /// Ya se en OneWay o TwoWay.
        /// </summary>
        /// <param name="value">valor que viene del source</param>
        /// <param name="targetType">tipo de dato del source</param>
        /// <param name="parameter">en caso de pasar algun parametro</param>
        /// <param name="culture">importante para traducciones (Localization)</param>
        /// <returns>Valor que acepta el target</returns>
        /// <exception cref="NotImplementedException"></exception>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            //convertimos un valor double
            //a un string con la informaicion
            //correspondiente a la categoria.
            if (value is double categoryResult)
            {
                if (categoryResult == 0)
                {
                    return string.Empty;
                }

                if (categoryResult <= 18.5)
                {
                    return $"{categoryResult} IMC - Peso bajo.";
                }
                else if (categoryResult >= 18.5d && categoryResult <= 24.9d)
                {
                    return $"{categoryResult} IMC - Peso normal.";
                }
                else if (categoryResult >= 25 && categoryResult <= 29.9d)
                {
                    return $"{categoryResult} IMC - Sobre peso.";
                }
                else
                {
                    //mayor que 30
                    return $"{categoryResult} IMC - Obesidad.";
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Se ejecuta cuando la informacion se mueve del
        /// Target hacia el Source unicamente en
        /// TwoWay y OneWayToSource bindings.
        /// </summary>
        /// <param name="value">valor que viene del target</param>
        /// <param name="targetType">tipo de dato del target</param>
        /// <param name="parameter">en caso de pasar algun parametro</param>
        /// <param name="culture">importante para traducciones (Localization)</param>
        /// <returns>Valor que acepta el Source</returns>
        /// <exception cref="NotImplementedException"></exception>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            //En este ejemplo
            //la conversion siempre es del Source al Target
            //ya que solo mostramos el resultado calculado desde el View Model
            //a un Label
            //Nunca ingresamos un valor, por  ejemplo a traves de un Entry
            throw new NotImplementedException();
        }
    }
}

