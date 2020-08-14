using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pomidorek
{
    public class PhoneValidation : ValidationRule, IValidation
    {
        public string Name => "Phone Validation";

        public string Description => "Numer jest nieprawidłowy!?!";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || !IsPhoneNumber(value as string))
            {
                return new ValidationResult(false, Description);
            }

            return new ValidationResult(true, Description);
        }

        //https://stackoverflow.com/questions/29970244/how-to-validate-a-phone-number
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^\d{3}-\d{3}-\d{3}$").Success;
        }

    }
}
