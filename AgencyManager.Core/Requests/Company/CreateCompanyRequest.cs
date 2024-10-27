using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Contact;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.Company
{
    public class CreateCompanyRequest : Request
    {
        public string Name { get; set; } = string.Empty;
        public string TradingName { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public CreateAddressRequest Address { get; set; }  = new(); 
        public IList<CreateContactRequest>? Contacts { get; set; } = [];
        public string? Logo { get; private set; }  
        
        public void Validate()
        {
            AddNotifications(new Contract<CreateCompanyRequest>().Requires()
                .IsNotNullOrEmpty(Name,"Name","Razão Social Inválida.")
                .IsLowerOrEqualsThan(Name, 60,"Name", "A Razão Social deve conter no máximo 60 caracteres.")

                .IsNotNullOrEmpty(TradingName,"TradingName","Nome Fantasia Inválido.")
                .IsLowerOrEqualsThan(TradingName, 60,"TradingName", "O Nome Fantasia deve conter no máximo 60 caracteres.")

                .Matches(Cnpj, @"^\d{14}$", "Cnpj", "O CNPJ deve conter 14 dígitos númericos.")

                .IsNotNull(Address,"Address","Endereço Inválido")                         
            );

            if(Address is not null)
            {
                Address.Validate();
                AddNotifications(Address.Notifications);
            }
        }
    }
}