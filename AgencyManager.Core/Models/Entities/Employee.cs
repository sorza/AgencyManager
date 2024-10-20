using AgencyManager.Core.Models.Account;
using AgencyManager.Core.Models.ValueObjects;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Employee : Entity
    {      
        private readonly IList<Contact> _contacts;

        public Employee(string name, string cpf, string rg, DateTime birthDay, Address address, Agency agency, Position position, IList<Contact>? contacts, User? user)
        {   
            AddNotifications(new Contract<Employee>().Requires()
                .IsNotNullOrEmpty(name, "Name", "Nome inválido.")
                .IsLowerOrEqualsThan(name, 100, "Name", "O nome deve conter no máximo 100 letras.")
                .IsGreaterOrEqualsThan(name, 5, "Name", "O nome deve conter no mínimo 5 letras.")

                .Matches(cpf, @"^\d{14}$", "Cpf", "O CPF deve conter 11 dígitos númericos.")

                .Matches(rg, @"^\d$", "Rg", "O RG deve conter apenas dígitos númericos.")
                .IsGreaterOrEqualsThan(rg, 4,"Rg", "O RG deve conter no mínimo 4 dígitos.")
                .IsLowerOrEqualsThan(rg, 14, "Rg", "O RG pode conter no máximo 14 dígitos.")

                .IsLowerOrEqualsThan(birthDay,DateTime.Now.AddYears(-16),"Birthday","A idade deve ser igual ou superior a 16 anos")
                .IsGreaterOrEqualsThan(birthDay,DateTime.Now.AddYears(-60),"Birthday","A idade deve ser igual ou inferior a 60 anos")

                .IsNotNull(address,"Address", "Endereço inválido")
                .IsNotNull(agency,"Agency", "Agência inválida")

            );

            Active = true;

            Name = name;
            Cpf = cpf;
            Rg = rg;
            BirthDay = birthDay;   

            Agency = agency;
            if(agency is not null) AgencyId = agency.Id;

            Position = position;
            if(position is not null) PositionId = position.Id;

            Address = address;
            _contacts = contacts ?? [];

            User = user ?? null;           
        }

        public bool Active { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public DateTime BirthDay { get; private set; }
        public Address Address { get; private set; }
        public Guid AgencyId { get; private set; }
        public virtual Agency Agency { get; private set; }
        public Guid PositionId { get; private set; }
        public virtual Position Position { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public DateTime DataDemissao { get; private set; }        
        public IReadOnlyCollection<Contact>? Contacts { get { return _contacts.ToArray(); }}
        public User? User { get; private set; }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

         public void AddContact(Contact contact)
        {
            if(contact.Validate()) _contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            if(contact is not null) _contacts.Remove(contact);
        }
   
        public void UpdateContact(Contact newContact, Guid id)
        {
            if(newContact is not null)
            {
                var contact = _contacts.FirstOrDefault(x => x.Id == id);

                if(contact is not null) contact.Update(newContact);                 
            }
        }
    }
}