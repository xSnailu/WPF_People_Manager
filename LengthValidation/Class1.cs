using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pomidorek
{
    public class LengthValidator : ValidationRule, IValidation
    {
        public string Name => "Length Validator";

        public string Description => "Napis jest zbyt krótki!?!";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value==null || (value as string).Length < 5)
            {
                return new ValidationResult(false, Description);
            }

            return new ValidationResult(true, Description);
        }
    }
}
