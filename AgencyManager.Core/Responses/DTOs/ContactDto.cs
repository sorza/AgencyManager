using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Responses.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public EContactType ContactType { get;  set; }
        public string Description { get;  set; } = string.Empty;
        public string Departament { get; set; } = string.Empty;
        public string Responsible { get; set; } = string.Empty;
        public int? AgencyId { get; private set; }
        public int? CompanyId { get; private set; }
        public int? EmployeeId { get; private set; }
    }
}
