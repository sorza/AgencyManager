using System.Text.RegularExpressions;
using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Models.Entities
{
    public class Contact
    {
        public Contact(EContactType contactType, string description, string departament)
        {
            ContactType = contactType;
            Description = description;
            Departament = departament;
        }

        public int Id { get; set; }
        public EContactType ContactType { get; private set; }
        public string Description { get; private set; }
        public string Departament { get; private set; }

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
    }
}