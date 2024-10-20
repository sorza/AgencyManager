using AgencyManager.Core.Models.Account;
using AgencyManager.Core.Models.ValueObjects;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Employee : Entity
    {      
        private readonly IList<Contact> _contacts;
        public Employee(string name, string cpf, string rg, DateTime birthDay, Address address, Agency agency, Position position, DateTime? dataHire = null,IList<Contact>? contacts = null, User? user = null)
        {   
            AddNotifications(new Contract<Employee>().Requires()
                .IsNotNullOrEmpty(name, "Name", "Nome inválido.")
                .IsLowerOrEqualsThan(name, 100, "Name", "O nome deve conter no máximo 100 letras.")
                .IsGreaterOrEqualsThan(name, 5, "Name", "O nome deve conter no mínimo 5 letras.")

                .Matches(cpf, @"^\d{11}$", "Cpf", "O CPF deve conter 11 dígitos númericos.")

                .Matches(rg, @"^\d+$", "Rg", "O RG deve conter apenas dígitos númericos.")
                .IsGreaterOrEqualsThan(rg, 4,"Rg", "O RG deve conter no mínimo 4 dígitos.")
                .IsLowerOrEqualsThan(rg, 14, "Rg", "O RG pode conter no máximo 14 dígitos.")

                .IsLowerOrEqualsThan(birthDay,DateTime.Now.AddYears(-16),"Birthday","A idade mínima é de 16 anos")
                .IsGreaterOrEqualsThan(birthDay,DateTime.Now.AddYears(-60),"Birthday","A idade máxima é de 60 anos")

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

            DateHire = dataHire ?? DateTime.Now;

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
        public DateTime DateHire { get; private set; }
        public DateTime DateDismiss { get; private set; }        
        public IReadOnlyCollection<Contact>? Contacts { get { return _contacts.ToArray(); }}
        public User? User { get; private set; }
       
        #region Overrides
        public override bool Equals(object? obj)
        {
            if(obj is null) return false;

            var employee = (Employee)obj;

            return employee.Active == Active &&
                    employee.Address == Address &&
                    employee.AgencyId == AgencyId &&
                    employee.BirthDay == BirthDay &&
                    employee.Rg == Rg &&
                    employee.Cpf == Cpf &&
                    employee.Name == Name &&
                    employee.Position == Position;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Active, Rg, Cpf, Name, Id);
        }
        #endregion
    }
}