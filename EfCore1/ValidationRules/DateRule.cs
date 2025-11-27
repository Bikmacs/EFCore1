using EfCore1.ValidationRules;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace EfCore1.ValidationRules
{
    internal class DateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value?.ToString()?.Trim() ?? string.Empty;

            if (DateTime.TryParse(input, cultureInfo, DateTimeStyles.None, out var inputDate))
            {
                if (inputDate >= DateTime.Now.Date)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Дата не может быть ранее текущей даты.");
            }

            return new ValidationResult(false, "Некорректный формат даты.");
        }
    }
}


