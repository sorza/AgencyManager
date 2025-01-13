
using AgencyManager.Core.Models.Entities.ValueObjects;

namespace AgencyManager.Core.DTOs
{
    public class AgencyDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public bool Active { get; set; }
        public Address Address { get; set; } = null!;
        public IList<ContactDto> Contacts { get; set; } = [];
        public string? Photo { get; set; }
    }
}
