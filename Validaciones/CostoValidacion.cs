using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace SistemaVentas.Validaciones
{
    public class CostoValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int costo = 0;
                try
                {
                    costo = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "El costo debe ser un numero");
                }

                if (costo >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "El costo debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner un costo");
        }
    }
}
