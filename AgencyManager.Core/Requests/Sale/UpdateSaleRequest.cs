using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Sale
{
    public class UpdateSaleRequest : Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Caixa inválido")]
        public int CashId { get; set; }

        [Required(ErrorMessage = "Empresa inválida")]
        public int CompanyId { get; set; }

        public decimal Money { get; set; }
        public decimal Digital { get; set; }
    }
}