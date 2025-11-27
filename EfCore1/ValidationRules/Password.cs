using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EfCore1.ValidationRules
{
    public class Password : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value?.ToString()?.Trim() ?? string.Empty;

            if (input.Length < 8)
            {
                return new ValidationResult(false, "Пароль должен быть не менее 8 символов.");
            }

            if (!Regex.IsMatch(input, "[a-z]"))
            {
                return new ValidationResult(false, "Пароль должен содержать строчные буквы .");
            }

            if (!Regex.IsMatch(input, "[0-9]"))
            {
                return new ValidationResult(false, "Пароль должен содержать цифры.");
            }
            if (!Regex.IsMatch(input, @"[\W_]"))
            {
                return new ValidationResult(false, "Пароль должен содержать спецсимволы.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
