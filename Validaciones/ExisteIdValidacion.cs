using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization; 

namespace SistemaVentas.Validaciones
{
    public class ExisteIdValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "");
                }



            }
            return new ValidationResult(false, "Debes poner un id");
        }
    }
}
