using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Common.CustomValidations
{
    public class ValidPositionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Cargo inválido");
            }

            if (value is int Id)
            {
                if (Id <= 0)
                {
                    return new ValidationResult("Cargo inválido");
                }

                return ValidationResult.Success!;
            }

            return new ValidationResult("Cargo inválido");
        }
    }   
}