using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Sale : Entity
    {
        public Sale(Guid cashId, Guid companyId, decimal money, decimal digital)
        {    
            CashId = cashId;           
            CompanyId = companyId;
            Money = money;
            Digital = digital;
        }

        public Guid CashId { get; private set; }
        public virtual Cash? Cash { get; private set; }
        public Guid CompanyId { get; private set; }
        public virtual Company? Company { get; private set; }
        public decimal Money { get; private set; }
        public decimal Digital { get; private set; }
        public decimal Total => Money + Digital;
    }
}