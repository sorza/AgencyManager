using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Responses.DTOs
{
    public class CashDto
    {
        public int Id { get; set; }
        public string User { get; set; } = string.Empty;  
        public int AgencyId { get; set; }
        public DateTime Date { get; set; }
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }
        public bool Status { get; set; } = true;
        public decimal Entries => Transactions.Where(t => t.Type == ETransactionType.Entry).Sum(x => x.Amount);
        public decimal Outputs => Transactions.Where(t => t.Type == ETransactionType.Output).Sum(x => x.Amount);
        public decimal TotalSalesAmount => Sales.Sum(x => x.Total);
        public decimal VirtualSalesAmount => VirtualSales.Sum(x => x.Amount);
        public decimal Balance => GetBalance();

        public IList<TransactionDto> Transactions { get; set; } = [];
        public IList<SaleDto> Sales { get; set; } = [];
        public IList<VirtualSaleDto> VirtualSales { get; set; } = [];

        private decimal GetBalance() =>
             EndValue + Transactions.Sum(x => x.Amount) + Sales.Sum(x => x.Money) - VirtualSalesAmount - StartValue;
    }
}
