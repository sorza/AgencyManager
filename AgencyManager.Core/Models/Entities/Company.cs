using AgencyManager.Core.Models.ValueObjects;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Company : Entity
    {
        private readonly IList<Contact> _contacts;

        public Company(string name, string tradingName, string cnpj, Address address, IList<Contact>? contacts, string? logo)
        {
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