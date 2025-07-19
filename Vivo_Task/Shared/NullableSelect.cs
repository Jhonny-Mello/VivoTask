using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Shared
{
    public sealed class FieldLengthAttribute : ValidationAttribute
    {
        private int _minValue { get; set; }
        private int _maxValue { get; set; }
        public FieldLengthAttribute(int minValue, int maxValue)
        {

            _minValue = minValue;
            _maxValue = maxValue;

            ErrorMessage = "O tamanho de(a) {0} precisa estar entre {1} e {2}";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                int objectLength = Convert.ToString(value).Length;
                if (objectLength < _minValue || objectLength > _maxValue)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name, _minValue, _maxValue);
        }

    }
}
