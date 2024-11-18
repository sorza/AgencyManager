using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Contact;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.Agency
{
    public class CreateAgencyRequest : Request
    {        
        public string Description { get;  set; } = string.Empty;
        public string Cnpj { get;  set; } = string.Empty;
        public CreateAddressRequest Address { get; set; } = new();
        public string? Photo { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateAgencyRequest>().Requires()
                .IsNotNullOrEmpty(Description, "Description", "A descrição é obrigatória.")
                .IsLowerThan(Description, 60, "Description", "A descrição deve conter no máximo 60 caracteres.")
                .IsGreaterThan(Description, 2, "Description", "A descrição deve conter no mínimo 2 caracteres.")

                .Matches(Cnpj, @"^\d{14}$", "Cnpj", "O CNPJ deve conter 14 dígitos númericos.")
                .IsNotNull(Address, "Address", "O Endereço é obrigatório.")
            );

            if(Address is not null)
            {
                Address.Validate();
                AddNotifications(Address.Notifications);
            }          
        }
    }
}