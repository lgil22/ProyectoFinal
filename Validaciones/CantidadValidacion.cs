using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace SistemaVentas.Validaciones
{
    public class CantidadValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int cantidad = 0;
                try
                {
                    cantidad = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "La cantidad debe ser un numero");
                }

                if (cantidad >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "La cantidad debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner una cantidad");
        }
    }
}
