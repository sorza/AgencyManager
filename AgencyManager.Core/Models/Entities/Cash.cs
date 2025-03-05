
using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Models.Entities
{
    public class Cash : Entity
    {
        private readonly IList<Transaction> _transactions = [];
        private readonly IList<Sale> _sales = [];
        private readonly IList<VirtualSale> _virtualSales =[];

        public Cash(string userId, DateTime date, decimal startValue, decimal endValue, int agencyId)
        {            
            UserId = userId;
            Date = date;
            StartValue = startValue;
            EndValue = endValue;
            AgencyId = agencyId;
        }

        public string UserId { get; private set; }
        public virtual Agency? Agency { get; private set; }
        public int AgencyId { get; private set; }
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
            EndValue + _transactions.Sum(x => x.Amount) + _sales.Sum(x => x.Money) - VirtualSalesAmount - StartValue;
        
    }
}