using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Sale
{
    public class CreateSaleRequest : Request
    {
        [Required(ErrorMessage ="Caixa inválido")]
        public int CashId { get;  set; }

        [Required(ErrorMessage = "Empresa inválida")]
        public int CompanyId { get;  set; }       
        public decimal Money { get;  set; }
        public decimal Digital { get;  set; }
    }
}