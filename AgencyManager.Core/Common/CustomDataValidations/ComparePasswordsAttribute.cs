namespace AgencyManager.Core.Common.CustomDataValidations
{
    using System.ComponentModel.DataAnnotations;

    public class ComparePasswordsAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public ComparePasswordsAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = value?.ToString();
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property is null)
            {
                return new ValidationResult($"Propriedade {_comparisonProperty} não encontrada.");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance)?.ToString();

            if (currentValue != comparisonValue)
            {
                return new ValidationResult("As senhas não coincidem.");
            }

            return ValidationResult.Success!;
        }
    }

}
