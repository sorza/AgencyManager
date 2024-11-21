using System.ComponentModel.DataAnnotations;
using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Requests.VirtualSale
{
    public class CreateVirtualSaleRequest : Request
    {
        [Required(ErrorMessage ="Caixa inválido")]
        public int CashId { get; set; }

        [Required(ErrorMessage = "Empresa inválida")]
        public int CompanyId { get;  set; }

        [Required(ErrorMessage = "Origem inválida")]
        public int OrignId { get; set; }

        [Required(ErrorMessage = "Destino inválido")]
        public int DestinationId { get; set; }

        [Required(ErrorMessage = "Valor inválido")]
        public decimal Amount { get;  set; }
       
        public EPaymentType PaymentType { get;  set; } = EPaymentType.PIX;
        public bool Paid { get;  set; } = true;

        [MaxLength(100, ErrorMessage = "A observação deve ter no máximo 100 caracteres")]
        public string? Observation { get;  set; }
       
    }
}