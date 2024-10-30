using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Models.Entities
{
    public class VirtualSale : Entity
    {
        public VirtualSale()
        {
            
        }
        public VirtualSale(int cashId, int companyId,int orignId, int destinationId, decimal amount, EPaymentType paymentType, bool paid, string? observation)
        {            
            CashId = cashId;
            CompanyId = companyId;            
            OrignId = orignId;           
            DestinationId = destinationId;          
            Amount = amount;
            PaymentType = paymentType;
            Paid = paid;
            Observation = observation;
        }

        public int CashId { get; private set; }
        public virtual Cash? Cash { get; private set; } 
        public int CompanyId { get; private set; }
        public virtual Company? Company { get; private set; } 
        public int OrignId { get; private set; }
        public virtual Locality? Orign { get; private set; }
        public int DestinationId { get; private set; }
        public virtual Locality? Destination { get; private set; }
        public decimal Amount { get; private set; }
        public EPaymentType PaymentType { get; private set; }
        public bool Paid { get; private set; } = true;
        public string? Observation { get; private set; }
    }
}