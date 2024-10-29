using AgencyManager.Core.Enums;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.Transaction
{
    public class CreateTransactionRequest : Request
    {
        public int CashId { get; set; }       
        public ETransactionType Type { get; set; } = ETransactionType.Output;
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        public void Validate()
        {
            var contract = new Contract<CreateTransactionRequest>();

            AddNotifications(contract.Requires()
                .IsGreaterThan(CashId, 0, "Identidicador de caixa inválido.")
                .IsEmail(UserId, "UserId", "Usuário inválido")
                .AreNotEquals(0, Amount, "A transação deve ter um valor diferente de zero.")  
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