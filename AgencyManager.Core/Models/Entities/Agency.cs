using AgencyManager.Core.Models.ValueObjects;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Agency : Entity
    {
        private readonly IList<Contact> _contacts;
        private readonly IList<Position> _positions;

        public Agency(string description, string cnpj, Address address, IList<Contact>? contacts, IList<Position>? positions, string? photo)
        {
            AddNotifications(new Contract<Agency>().Requires()
                .IsNotNullOrEmpty(description,"Description","O nome/descrição inválido.")
                .IsLowerThan(Description,60,"Description", "O nome/descrição deve conter no máximo 60 caracteres.")

                .Matches(cnpj, @"^\d{8}$", "Cnpj", "O CNPJ deve conter 14 dígitos númericos.")

                .IsNotNull(address,"Address","Informe um endereço")
            );

            Description = description;
            Cnpj = cnpj;
            Address = address;    

            Active = true;

            Photo = photo ?? "";
            _positions = positions ?? [];
            _contacts = contacts ?? [];
        }

        public string Description { get; private set; }
        public string Cnpj { get; private set; }
        public bool Active { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Contact>? Contacts { get { return _contacts.ToArray(); }}
        public IReadOnlyCollection<Position>? Positions { get { return _positions.ToArray(); }}
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

        public void UpdatePosition(Position positionUpdated)
        {
            if(positionUpdated.IsValid)
            { 
                int index = ((List<Position>)_positions).FindIndex(x => x.Id == positionUpdated.Id);
                _positions[index] = positionUpdated;
            }
        }


        public void AddContact(Contact contact)
        {
            if(contact.Validate()) _contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            _contacts.Remove(contact);
        }
   
        public void UpdateContact(Contact contactUpdated)
        {
            if(contactUpdated is not null) 
            {
                var contact = _contacts.FirstOrDefault(x => x.Id == contactUpdated.Id)!;
                contact.UpdateContact(contactUpdated); 
            }
        }
    }
}