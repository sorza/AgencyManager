using AgencyManager.Core.Models.Account;
using AgencyManager.Core.Models.ValueObjects;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Employee : Entity
    {      
        private readonly IList<Contact> _contacts;
        public Employee(string name, string cpf, string rg, DateTime birthDay, Address address, int agencyId, int positionId, string? userId = null , DateTime? dataHire = null,IList<Contact>? contacts = null)
        {   
            Active = true;

            Name = name;
            Cpf = cpf;
            Rg = rg;
            BirthDay = birthDay;   

            AgencyId = agencyId;
            PositionId = positionId;

            DateHire = dataHire ?? DateTime.Now;

            Address = address;
            _contacts = contacts ?? [];

            UserId = userId ?? string.Empty;         
        }

        public bool Active { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public DateTime BirthDay { get; private set; }
        public Address Address { get; private set; }
        public int AgencyId { get; private set; }
        public virtual Agency? Agency { get; private set; }
        public int PositionId { get; private set; }
        public virtual Position? Position { get; private set; }
        public DateTime DateHire { get; private set; }
        public DateTime DateDismiss { get; private set; }        
        public IReadOnlyCollection<Contact>? Contacts { get { return _contacts.ToArray(); }}
        public string UserId { get; private set; }
        public User? User { get; private set; }       
    }
}