using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;

namespace AgencyManager.Core.Responses.DTOs
{
    public class TransactionDto
    {
        public int CashId { get; private set; }       
        public ETransactionType Type { get; private set; } = ETransactionType.Output;
        public decimal Amount { get; private set; }
        public string? Description { get; private set; }
    }
}
