using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Sale : Entity
    {
        public Sale(int cashId, int companyId, decimal money, decimal digital)
        {           
             AddNotifications(new Contract<Cash>().Requires()                               
                .IsGreaterOrEqualsThan(money, 0, "Money", "O troco inicial deve ser positivo")
                .IsGreaterOrEqualsThan(digital, 0, "Digital", "O troco final deve ser positivo")
            );
            
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