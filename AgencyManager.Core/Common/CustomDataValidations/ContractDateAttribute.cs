using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Common.CustomValidations
{
    public class ContractDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext) 
        {
            if (value == null)
            {
                return new ValidationResult("Data de contratação inválida");
            }

            if (value is DateTime date)
            {
                if(date > DateTime.Now)
                {
                    return new ValidationResult("A data não pode ser futura");
                }

                if(date < date.AddMonths(-3))
                {
                    return new ValidationResult("A data não pode ser inferior a 3 meses");
                }

                return ValidationResult.Success!;
            }

            return new ValidationResult("Data de contratação inválida");
        }
    }
}
