using System.Text.RegularExpressions;
using AgencyManager.Core.Enums;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Contact : Entity
    {
        public Contact(EContactType contactType, string description, string departament)
        {
            AddNotifications(new Contract<Contact>().Requires()
                .IsNotNull(contactType,"ContactType","O tipo é obrigatório.")

                .IsNotNullOrEmpty(description,"Description","Bairro inválido.")
                .IsGreaterThan(description, 7, "Description","O contato deve ter no mínimo 7 caracteres")
                .IsLowerThan(description, 70, "Description","O contato deve ter no máximo 70 caracteres") 

                .IsNotNullOrEmpty(departament,"Description","Departamento inválido.")
                .IsGreaterThan(departament, 2, "Description","O departamento deve ter no mínimo 2 caracteres")
                .IsLowerThan(departament, 70, "Description","O departamento deve ter no máximo 70 caracteres")      
            );

            ContactType = contactType;
            Description = description;
            Departament = departament;
        }
        public EContactType ContactType { get; private set; }
        public string Description { get; private set; }
        public string Departament { get; private set; }

        #region Private Methods
        private bool WhatsAppValidate()
        {
            var phone = PhoneValidate();
            var CellPhone = CellPhoneValidate();

            if(phone || CellPhone) 
                return true;
            return false;
        }

        private bool PhoneValidate()
        {
            string number = Description.Replace("(","").Replace(")","").Replace("-","").Trim(); 
            return new Regex(@"^\d{10}$").IsMatch(number);
        }    

        private bool CellPhoneValidate()
        {
            string number = Description.Replace("(","").Replace(")","").Replace("-","").Trim(); 
            return new Regex(@"^\d{11}$").IsMatch(number);
        }   

        private bool EmailValidate()
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,}$";
            return new Regex(pattern).IsMatch(Description);
        }
        #endregion
        
        #region Public Methods
        public bool Validate()
        {
           switch (ContactType)
           {
            case EContactType.Phone: return PhoneValidate();
            case EContactType.CellPhone: return CellPhoneValidate();
            case EContactType.Email: return EmailValidate();
            case EContactType.WhatsApp: return WhatsAppValidate();
            default: return false;
           }
        }        
        public void UpdateContact(Contact contact)
        {
            if(contact.Validate())
            {
                ContactType = contact.ContactType;
                Description = contact.Description;
                Departament = contact.Departament;
            }
        }
        
        #endregion

        #region Overrides
        public override bool Equals(object? obj)
        {
            if(obj is null) return false;

            var contact = (Contact)obj;

            return ContactType == contact.ContactType &&
                    Description == contact.Description &&
                    Departament == contact.Departament;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ContactType, Description, Departament);
        }
        #endregion
    }
}