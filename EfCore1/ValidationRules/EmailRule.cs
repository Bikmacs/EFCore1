using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EfCore1.ValidationRules
{
    public class EmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value?.ToString()?.Trim() ?? string.Empty;

            if (!input.Contains("@") || !input.Contains("."))
            {
                return new ValidationResult(false, "Некорректный формат email.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
