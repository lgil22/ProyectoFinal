using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace SistemaVentas.Validaciones
{
     public class ExistenciaValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int Existencia = 0;
                try
                {
                    Existencia= Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "la Existencia debe ser un numero");
                }

                if (Existencia >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "la existencia debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner una existencia");
        }
    }
}
