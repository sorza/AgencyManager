using AgencyManager.Core.Models.Entities.ValueObjects;

namespace AgencyManager.Core.Models.Entities
{
    public class Agency : Entity
    {
        private readonly IList<Contact> _contacts;
        private readonly IList<Position> _positions;

        public Agency(string description, string cnpj, Address address, IList<Contact> contacts, IList<Position> positions, string photo)
        {
            Description = description;
            Cnpj = cnpj;
            Address = address;
            _contacts = contacts ?? [];
            Photo = photo;
            Active = true;
            _positions = positions ?? [];
        }
        public int Id { get; set; }
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
            if(position.Validate()) _positions.Add(position); 
        }

        public void RemovePosition(Position position)
        {
            _positions.Remove(position);
        }

        public void AddContact(Contact contact)
        {
            if(contact.Validate()) _contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            _contacts.Remove(contact);
        }

        public void UpdatePosition(Position positionUpdated)
        {
            if(positionUpdated.Validate())
            { 
                int index = ((List<Position>)_positions).FindIndex(x => x.Id == positionUpdated.Id);
                _positions[index] = positionUpdated;
            }
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