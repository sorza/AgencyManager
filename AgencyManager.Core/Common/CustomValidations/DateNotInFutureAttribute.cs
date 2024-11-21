using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Common.CustomValidations
{
    public class DateNotInFutureAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext) 
        {           
            if (value is DateTime dateTimeValue)            
                if (dateTimeValue > DateTime.Now)                 
                    return new ValidationResult("A data não pode ser futura.");                
            
            return ValidationResult.Success!; 
        }
    }
}
