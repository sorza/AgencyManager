using AgencyManager.Core.Common.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Cash
{
    public class UpdateCashRequest : Request
    {
        public int Id { get; set; }
        
        public bool Status { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        [ContractDate]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Informe o troco inicial")]       
        public decimal StartValue { get; set; }

        [Required(ErrorMessage = "Informe o troco final")]        
        public decimal EndValue { get; set; }
    }
}