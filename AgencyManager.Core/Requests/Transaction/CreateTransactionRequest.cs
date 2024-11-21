using AgencyManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Transaction
{
    public class CreateTransactionRequest : Request
    {
        [Required(ErrorMessage ="Caixa inválido")]
        public int CashId { get; set; }

        [Required(ErrorMessage = "Tipo de transação inválida")]
        public ETransactionType Type { get; set; } = ETransactionType.Output;

        [Required(ErrorMessage ="Informe o valor da transação")]
        public decimal Amount { get; set; }

        [MaxLength(100,ErrorMessage = "A descrição deve ter no máximo 100 caracteres")]
        public string? Description { get; set; }
      
    }
}