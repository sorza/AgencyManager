using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Common.CustomValidations
{
    public class AgeToHireAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {           
            if (value == null)
            {
                return new ValidationResult("Data de nascimento inválida");
            }
         
            if (value is DateTime birthday)
            {
                if (DateTime.Now.AddYears(-16) < birthday)
                {
                    return new ValidationResult("A idade mínima é de 16 anos");
                }

                if (DateTime.Now.AddYears(-60) > birthday)
                {
                    return new ValidationResult("A idade máxima é de 60 anos");
                }

                return ValidationResult.Success!;
            }

            return new ValidationResult("Data de nascimento inválida");
        }
    }
}
