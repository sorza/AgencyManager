using AgencyManager.Core.Enums;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.Transaction
{
    public class UpdateTransactionRequest : Request
    {
        public int Id { get; set; }
        public ETransactionType Type { get; set; } = ETransactionType.Output;
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        public void Validate()
        {
            var contract = new Contract<UpdateTransactionRequest>();

            AddNotifications(contract.Requires()                
                .AreNotEquals(0, Amount, "A transação deve ter um valor diferente de zero.")  
                .IsGreaterThan(Id, 0, "O identificador da transação é inválido")
            );

            if(Description is not null)
            {
                AddNotifications(contract.Requires()
                    .IsLowerOrEqualsThan(Description.Length, 100, "A descrição deve ter no máximo 100 caracteres")
                );
            }
        }
    }
}