using AgencyManager.Core.Models.ValueObjects;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Agency : Entity
    {
        private readonly IList<Contact> _contacts;
        private readonly IList<Position> _positions;
        private readonly IList<Employee> _emplooyes;

        public Agency(string description, string cnpj, Address address, IList<Contact>? contacts = null, IList<Position>? positions = null, IList<Employee>? employees = null, string? photo = null)
        {
            AddNotifications(new Contract<Agency>().Requires()
                .IsNotNullOrEmpty(description,"Description","O nome/descrição inválido.")
                .IsLowerThan(description, 60,"Description", "O nome/descrição deve conter no máximo 60 caracteres.")
                .IsGreaterThan(description, 2,"Description", "O nome/descrição deve conter no mínimo 2 caracteres.")

                .Matches(cnpj, @"^\d{14}$", "Cnpj", "O CNPJ deve conter 14 dígitos númericos.")

                .IsNotNull(address,"Address","Informe um endereço")
            );

            Description = description;
            Cnpj = cnpj;
            Address = address;    

            Active = true;

            Photo = photo ?? "";
            _positions = positions ?? [];
            _contacts = contacts ?? [];
            _emplooyes = employees ?? [];
        }

        public string Description { get; private set; }
        public string Cnpj { get; private set; }
        public bool Active { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Contact>? Contacts { get { return _contacts.ToArray(); }}
        public IReadOnlyCollection<Position>? Positions { get { return _positions.ToArray(); }}
        public IReadOnlyCollection<Employee>? Employees { get { return _emplooyes.ToArray(); }}
        public string? Photo { get; private set; }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void AddPosition(Position position)
        {
            if(position.IsValid) _positions.Add(position); 
        }

        public void RemovePosition(Position position)
        {
            _positions.Remove(position);
        }

        public void UpdatePosition(Position newPosition, Guid id)
        {
            if(newPosition.IsValid)
            { 
                var position = _positions.FirstOrDefault(x => x.Id == id);

                if(position is not null) position.Update(newPosition);
            }
        }

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

        public void HireAnEmployee(Employee employee)
        {
            if(employee.IsValid)            
                _emplooyes.Add(employee);
        }

        public void DismissAnEmployee(Employee employee, DateTime? dateDismiss = null)
        {
            if(employee is not null)
                if(_emplooyes.Contains(employee))           
                    employee.Dismiss(dateDismiss);            
        }

        public void UpdateAnEmployee(Employee updateEmployee, Guid id)
        {
            if(updateEmployee is not null)
            {
                var employee = _emplooyes.FirstOrDefault(x => x.Id == id);
                if(employee is not null) employee.Update(updateEmployee);
            }      
        }

        public void RemoveAnEmployee(Employee employee)
        {
             if(employee is not null)
                if(_emplooyes.Contains(employee)) _emplooyes.Remove(employee);
        }
    }
}