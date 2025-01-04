using AgencyManager.Core.Models.Entities.ValueObjects;

namespace AgencyManager.Core.Models.Entities
{
    public class Agency : Entity
    {       
        private IList<Position> _positions = [];
        private IList<Employee> _emplooyes = [];
        private IList<ContractService> _contracts = [];
        private IList<Cash> _cash = [];

        public Agency()
        {
            
        }

        public Agency(string description, string cnpj, Address address, string? photo = null)
        {           
            Description = description;
            Cnpj = cnpj;
            Address = address;                
            Active = true;
            Photo = photo ?? "";           
        }

        public string Description { get; private set; }
        public string Cnpj { get; private set; }
        public bool Active { get; private set; }
        public Address Address { get; private set; }
        public List<Contact>? Contacts { get; set; }
        public IReadOnlyCollection<Position>? Positions { get { return _positions.ToArray(); }}
        public IReadOnlyCollection<Employee>? Employees { get { return _emplooyes.ToArray(); }}
        public IReadOnlyCollection<ContractService>? Contracts { get { return _contracts.ToArray(); }}
        public IReadOnlyCollection<Cash>? Cash { get { return _cash.ToArray(); } }
        public string? Photo { get; private set; }      
    }
}