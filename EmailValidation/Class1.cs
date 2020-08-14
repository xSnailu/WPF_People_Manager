using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pomidorek
{
    public class EmailValidator : ValidationRule, IValidation
    {
        public string Name => "Email Validator";

        public string Description => "Email jest nieprawidłowy!?!";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || !IsEmail(value as string))
            {
                return new ValidationResult(false, Description);
            }

            return new ValidationResult(true, Description);
        }

        //https://stackoverflow.com/questions/5342375/regex-email-validation
        public static bool IsEmail(string number)
        {
            return Regex.Match(number, @"^[\w-]+@([\w-]+\.)+[\w-]+$").Success;
        }
    }
}
