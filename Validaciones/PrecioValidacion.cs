using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace SistemaVentas.Validaciones
{
    public class PrecioValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int precio = 0;
                try
                {
                    precio = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "El Precio debe ser un numero");
                }

                if (precio >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "El Precio debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner un Precio");
        }
    }
}
