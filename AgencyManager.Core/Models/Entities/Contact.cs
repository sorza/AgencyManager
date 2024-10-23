using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Models.Entities
{
    public class Contact : Entity
    {
        public Contact(EContactType contactType, string description, string departament)
        {         
            ContactType = contactType;
            Description = description;
            Departament = departament;
        }
        public EContactType ContactType { get; private set; }
        public string Description { get; private set; }
        public string Departament { get; private set; }
    }
}