using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Contact;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.Agency
{
    public class UpdateAgencyRequest : Request
    {
        public int Id { get; set; }
        public string Description { get;  set; } = string.Empty;
        public string Cnpj { get;  set; } = string.Empty;
        public UpdateAddressRequest Address { get; set; } = new();
        public IList<UpdateContactRequest> Contacts { get; set; } = [];
        public string? Photo { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateAgencyRequest>().Requires()
                .IsNotNullOrEmpty(Description,"Description","A descrição é obrigatória.")
                .IsGreaterThan(Id, 0, "Identificador de agência inválido.")
                .IsLowerThan(Description, 60,"Description", "A descrição deve conter no máximo 60 caracteres.")
                .IsGreaterThan(Description, 2,"Description", "A descrição deve conter no mínimo 2 caracteres.")

                .Matches(Cnpj, @"^\d{14}$", "Cnpj", "O CNPJ deve conter 14 dígitos númericos.")
                .IsNotNull(Address, "Address", "O Endereço é obrigatório.")                
                .IsGreaterOrEqualsThan(Contacts.Count, 1, "É necessário cadastrar pelo menos um contato")
            );

            if(Address is not null)
            {
                Address.Validate();
                AddNotifications(Address.Notifications);
            }
            foreach(var contact in Contacts)
            {
                contact.Validate();
                AddNotifications(contact.Notifications);
            }
        }
    }
}