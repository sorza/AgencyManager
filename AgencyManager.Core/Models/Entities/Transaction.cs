using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Models.Entities
{
    public class Transaction : Entity
    {
        public Transaction(int cashId, ETransactionType type, decimal amount, string? description)
        {           
           CashId = cashId;
           Type = type;
           Amount = amount;
           Description = description;
        }

        public int CashId { get; private set; }
        public virtual Cash? Cash { get; private set; }
        public ETransactionType Type { get; private set; } = ETransactionType.Output;
        public decimal Amount { get; private set; }
        public string? Description { get; private set; }
    }
}