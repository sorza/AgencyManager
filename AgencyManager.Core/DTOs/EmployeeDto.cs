using AgencyManager.Core.Models.Entities;

namespace AgencyManager.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
        public int AgencyId { get; set; }
        public int PositionId { get; set; }
        public virtual PositionDto? Position { get; set; }
        public DateTime DateHire { get;  set; }
        public DateTime DateDismiss { get;  set; }
        public List<Contact>? Contacts { get; set; } = [];
    }
}
