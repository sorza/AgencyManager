using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Responses.DTOs
{
    public class VirtualSaleDto
    {
        public int CashId { get; private set; }      
        public int CompanyId { get; private set; }       
        public int OrignId { get; private set; }       
        public int DestinationId { get; private set; }      
        public decimal Amount { get; private set; }
        public EPaymentType PaymentType { get; private set; }
        public bool Paid { get; private set; } = true;
        public string? Observation { get; private set; }
    }
}