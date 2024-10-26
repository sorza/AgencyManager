
using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Account;

namespace AgencyManager.Core.Models.Entities
{
    public class Cash : Entity
    {
        private readonly IList<Transaction> _transactions = [];
        private readonly IList<Sale> _sales = [];
        private readonly IList<VirtualSale> _virtualSales =[];

        public Cash(string userId, DateTime date, decimal startValue, decimal endValue)
        {            
            UserId = userId;
            Date = date;
            StartValue = startValue;
            EndValue = endValue;
        }

        public string UserId { get; private set; }
        public virtual User? User { get; private set; }
        public DateTime Date { get; private set; }
        public decimal StartValue { get; private set; }
        public decimal EndValue { get; private set; }
        public bool Status { get; private set; } = true;
        public decimal Entries => _transactions.Where(t => t.Type == ETransactionType.Entry).Sum(x=> x.Amount);
        public decimal Outputs => _transactions.Where(t => t.Type == ETransactionType.Output).Sum(x=> x.Amount);
        public decimal TotalSalesAmount => _sales.Sum(x => x.Total);
        public decimal VirtualSalesAmount => _virtualSales.Sum(x => x.Amount);
        public decimal Balance => GetBalance();

        public IReadOnlyCollection<Transaction>? Transactions { get { return _transactions.ToArray(); }}
        public IReadOnlyCollection<Sale>? Sales { get { return _sales.ToArray(); }}
        public IReadOnlyCollection<VirtualSale>? VirtualSales { get { return _virtualSales.ToArray(); }}

        private decimal GetBalance() =>        
            StartValue + _transactions.Sum(x => x.Amount) + _sales.Sum(x => x.Money) - VirtualSalesAmount - EndValue;
        
    }
}