using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;

namespace AgencyManager.Core.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public EContactType ContactType { get;  set; }
        public string Description { get;  set; }
        public string Departament { get;  set; }
        public int? AgencyId { get; private set; }
        public int? CompanyId { get; private set; }
        public int? EmployeeId { get; private set; }
    }
}
