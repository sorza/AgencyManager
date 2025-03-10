using AgencyManager.Core.Common.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Cash
{
    public class CreateCashRequest : Request
    {
        [Required(ErrorMessage = "Agência inválida")]
        public int AgencyId { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        [ContractDate]
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="Informe o troco inicial")]        
        public decimal StartValue { get; set; }

        [Required(ErrorMessage = "Informe o troco final")]        
        public decimal EndValue { get; set; }
    }
}