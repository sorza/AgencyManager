
using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Account;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Cash : Entity
    {
        private readonly IList<Transaction> _transactions = [];
        private readonly IList<Sale> _sales = [];
        private readonly IList<VirtualSale> _virtuaSales =[];

        public Cash(string userId, DateTime date, decimal startValue, decimal endValue)
        {
            AddNotifications(new Contract<Cash>().Requires()
                .IsEmail(userId, "UserId", "Email inválido.")
                .IsLowerOrEqualsThan(date, DateTime.Now, "A data não pode ser futura")
                .IsGreaterOrEqualsThan(startValue, 0, "StartValue", "O troco inicial deve ser positivo")
                .IsGreaterOrEqualsThan(endValue, 0, "EndValue", "O troco final deve ser positivo")
            );

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
        public decimal TotalSales => _sales.Sum(x => x.Total);
        public decimal VirtualSales => _virtuaSales.Sum(x => x.Amount);
        public decimal Balance => GetBalance();

        public IReadOnlyCollection<Transaction>? Transactions { get { return _transactions.ToArray(); }}
        public IReadOnlyCollection<Sale>? Sales { get { return _sales.ToArray(); }}
        public IReadOnlyCollection<VirtualSale>? _virtualSales { get { return _virtuaSales.ToArray(); }}

        private decimal GetBalance() =>        
            StartValue + _transactions.Sum(x => x.Amount) + _sales.Sum(x => x.Money) - VirtualSales - EndValue;
        
    }
}