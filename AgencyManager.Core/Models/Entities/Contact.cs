using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Models.Entities
{
    public class Contact : Entity
    {
        public Contact(EContactType contactType, string description, string departament, int? agencyId = null, int? companyId = null, int? employeeId = null)
        {
            ContactType = contactType;
            Description = description;
            Departament = departament;
            AgencyId = agencyId;
            CompanyId = companyId;
            EmployeeId = employeeId;
        }
        public EContactType ContactType { get; private set; }
        public string Description { get; private set; }
        public string Departament { get; private set; }       
        public int? AgencyId {  get; private set; }
        public virtual Agency? Agency { get; private set; }
        public int? CompanyId { get; private set; }
        public virtual Company? Company { get; private set; }
        public int? EmployeeId { get; private set; }
        public virtual Employee? Employee { get; private set; }
       
        public override bool Equals(object? obj)
        {           
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }
            var contact = (Contact)obj;

            return ContactType == contact.ContactType &&
                    Description == contact.Description &&
                    Departament == contact.Departament &&
                    AgencyId == contact.AgencyId &&
                    CompanyId == contact.CompanyId &&
                    EmployeeId == contact.EmployeeId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ContactType, Description, Departament);
        }

    }
}