using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Crudwpf
{
    public class IntValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value as string, out _))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Invalid input. Please enter an integer.");
        }
    }
}
