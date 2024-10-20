using AgencyManager.Core.Models.ValueObjects;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Company : Entity
    {
        private readonly IList<Contact> _contacts;

        public Company(string name, string tradingName, string cnpj, Address address, IList<Contact>? contacts, string? logo)
        {
            AddNotifications(new Contract<Agency>().Requires()
                .IsNotNullOrEmpty(name,"Name","Razão Social Inválida.")
                .IsLowerOrEqualsThan(name, 60,"Name", "A Razão Social deve conter no máximo 60 caracteres.")

                .IsNotNullOrEmpty(tradingName,"TradingName","Nome Fantasia Inválido.")
                .IsLowerOrEqualsThan(tradingName, 60,"TradingName", "O Nome Fantasia deve conter no máximo 60 caracteres.")

                .Matches(cnpj, @"^\d{14}$", "Cnpj", "O CNPJ deve conter 14 dígitos númericos.")

                .IsNotNull(address,"Address","Endereço Inválido")            
            );

            Name = name;
            TradingName = tradingName;
            Cnpj = cnpj;
            Address = address;
            _contacts = contacts ?? [];
            Logo = logo ?? string.Empty;
        }

        public string Name { get; private set; }
        public string TradingName { get; private set; }
        public string Cnpj { get; private set; }
        public Address Address { get; private set; }   
        public IReadOnlyCollection<Contact>? Contacts { get { return _contacts.ToArray(); }}
        public string? Logo { get; private set; }    
    }
}