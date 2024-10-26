
using System.Text.RegularExpressions;
using AgencyManager.Core.Enums;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.Contact
{
    public class UpdateContactRequest : Request
    {
        public Guid Id { get; set; }
        public EContactType ContactType { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Departament { get; set; } = string.Empty;
        
        public void Validate()
        {            
            AddNotifications(new Contract<UpdateContactRequest>().Requires()
                .IsNotNull(ContactType,"ContactType","O tipo é obrigatório.")

                .IsNotNullOrEmpty(Description,"Description","Contato inválido.")
                .IsGreaterThan(Description, 7, "Description","O contato deve ter no mínimo 7 caracteres")
                .IsLowerThan(Description, 70, "Description","O contato deve ter no máximo 70 caracteres") 

                .IsNotNullOrEmpty(Departament,"Description","Departamento inválido.")
                .IsGreaterThan(Departament, 2, "Description","O departamento deve ter no mínimo 2 caracteres")
                .IsLowerThan(Departament, 70, "Description","O departamento deve ter no máximo 70 caracteres")      
            );

           switch (ContactType)
           {
            case EContactType.Phone: 
                if (!PhoneValidate()) {AddNotification("ContactType","Telefone inválido");}
                break;
            case EContactType.CellPhone: 
                if(!CellPhoneValidate()) {AddNotification("ContactType","Celular inválido");}
                break;
            case EContactType.Email: 
                if(!EmailValidate()) {AddNotification("ContactType","Email inválido");}
                break;
            case EContactType.WhatsApp: 
                if(!WhatsAppValidate()) {AddNotification("ContactType","Email inválido");}
                break;
            default: AddNotification("ContactType","Tipo de contato inválido");
                break;
           }
        }

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
    }
}