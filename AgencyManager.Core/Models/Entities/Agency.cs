using AgencyManager.Core.Models.Entities.ValueObjects;

namespace AgencyManager.Core.Models.Entities
{
    public class Agency : Entity
    {
        private readonly IList<Contact> _contacts = [];
        private readonly IList<Position> _positions = [];
        private readonly IList<Employee> _emplooyes = [];
        private readonly IList<ContractService> _contracts = [];
        private readonly IList<Cash> _cash = [];

        public Agency()
        {
            
        }

        public Agency(string description, string cnpj, Address address, IList<Contact> contacts, string? photo = null)
        {           
            Description = description;
            Cnpj = cnpj;
            Address = address;    
            
            Active = true;

            Photo = photo ?? "";
            _contacts = contacts;
        }

        public string Description { get; private set; }
        public string Cnpj { get; private set; }
        public bool Active { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Contact>? Contacts { get { return _contacts.ToArray(); }}
        public IReadOnlyCollection<Position>? Positions { get { return _positions.ToArray(); }}
        public IReadOnlyCollection<Employee>? Employees { get { return _emplooyes.ToArray(); }}
        public IReadOnlyCollection<ContractService>? Contracts { get { return _contracts.ToArray(); }}
        public IReadOnlyCollection<Cash>? Cash { get { return _cash.ToArray(); } }
        public string? Photo { get; private set; }
    }
}