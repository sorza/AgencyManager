using AgencyManager.Core.Models.Entities.ValueObjects;

namespace AgencyManager.Core.Models.Entities
{
    public class Company : Entity
    {      
        public Company()
        {
            
        }
        public Company(string name, string tradingName, string cnpj, Address address, string? logo)
        {
            Name = name;
            TradingName = tradingName;
            Cnpj = cnpj;
            Address = address;            
            Logo = logo ?? string.Empty;
        }

        public string Name { get; private set; }
        public string TradingName { get; private set; }
        public string Cnpj { get; private set; }
        public Address Address { get; private set; }
        public List<Contact>? Contacts { get; set; } = [];
        public string? Logo { get; private set; }    
    }
}