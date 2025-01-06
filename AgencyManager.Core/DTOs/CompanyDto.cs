using AgencyManager.Core.Models.Entities.ValueObjects;

namespace AgencyManager.Core.DTOs
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TradingName { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public Address Address { get; set; } = null!;
        public string? Logo { get; set; }
    }
}
