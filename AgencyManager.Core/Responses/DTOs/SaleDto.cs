using AgencyManager.Core.Models.Entities;

namespace AgencyManager.Core.Responses.DTOs
{
    public class SaleDto
    {
        public int CashId { get; private set; }       
        public int CompanyId { get; private set; }       
        public decimal Money { get; private set; }
        public decimal Digital { get; private set; }
        public decimal Total => Money + Digital;
    }
}