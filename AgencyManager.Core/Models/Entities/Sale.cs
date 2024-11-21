namespace AgencyManager.Core.Models.Entities
{
    public class Sale : Entity
    {
        public Sale(int cashId, int companyId, decimal money, decimal digital)
        {    
            CashId = cashId;           
            CompanyId = companyId;
            Money = money;
            Digital = digital;
        }

        public int CashId { get; private set; }
        public virtual Cash? Cash { get; private set; }
        public int CompanyId { get; private set; }
        public virtual Company? Company { get; private set; }
        public decimal Money { get; private set; }
        public decimal Digital { get; private set; }
        public decimal Total => Money + Digital;
    }
}