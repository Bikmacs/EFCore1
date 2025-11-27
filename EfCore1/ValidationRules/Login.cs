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
    public class Login : ValidationRule
    {
        private static readonly Regex TextRegex = new Regex(@"^[a-zA-Zа-яА-ЯёЁ\s-]+$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString()!.Trim();

            if (string.IsNullOrEmpty(input))
            {
                return new ValidationResult(false, "Поле должно быть заполнено.");
            }

            if (input.Length < 5)
            {
                return new ValidationResult(false, "Логин должен содержать минимум 5 символов.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
