using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarriott.CustomValidations
{
    public class ValidateDateRange : ValidationAttribute
    {
        public ValidateDateRange(int monthsSpan)
        {
            this.MonthsSpan = monthsSpan;
        }

        public int MonthsSpan { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var date = (DateTime)value;
                var now = DateTime.Now;
                var futureDate = now.AddMonths(this.MonthsSpan);

                if (now <= date && date < futureDate)
                {
                    return null;
                }
            }

            return new ValidationResult(this.FormatErrorMessage(this.ErrorMessage));
        }
    }
}
