using AgencyManager.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AgencyManager.Core.Common.CustomValidations
{
    public class ContactValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var contactTypeProperty = validationContext.ObjectType.GetProperty("ContactType");
            var descricaoProperty = validationContext.ObjectType.GetProperty("Description");

            if (contactTypeProperty is null || descricaoProperty is null)
                return new ValidationResult("É obrigatório informar o tipo de contato e sua descrição.");

            var contactType = (EContactType)contactTypeProperty.GetValue(validationContext.ObjectInstance)!;
            var description = descricaoProperty.GetValue(validationContext.ObjectInstance)!.ToString();

            switch (contactType)
            {
                case EContactType.Fixo:
                    if (!PhoneValidate(description!)) return new ValidationResult("Telefone inválido.");
                    break;

                case EContactType.Celular:
                    if (!CellPhoneValidate(description!)) return new ValidationResult("Celular inválido");
                    break;

                case EContactType.WhatsApp:
                    if (!WhatsAppValidate(description!)) return new ValidationResult("WhatsApp inválido");
                    break;

                case EContactType.Email:
                    if (!new EmailAddressAttribute().IsValid(description))
                        return new ValidationResult("Email inválido");
                    break;

                default:
                    return new ValidationResult("Tipo de contato inválido");
            }

            return ValidationResult.Success!;
        }

        #region Private Methods
        private bool WhatsAppValidate(string description)
        {
            var phone = PhoneValidate(description);
            var CellPhone = CellPhoneValidate(description);

            if (phone || CellPhone)
                return true;
            return false;
        }

        private bool PhoneValidate(string description)
        {
            string number = description.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            return new Regex(@"^\d{10}$").IsMatch(number);
        }

        private bool CellPhoneValidate(string description)
        {
            string number = description.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            return new Regex(@"^\d{11}$").IsMatch(number);
        }

        #endregion
    }
}

