using AgencyManager.Core.Common.CustomValidations;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Cash
{
    public class CreateCashRequest : Request
    {
        [Required(ErrorMessage = "Agência inválida.")]
        public int AgencyId { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        [DateNotInFuture]
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="Informe o troco inicial")]
        [MinLength(0, ErrorMessage = "O troco não pode ser negativo")]
        public decimal StartValue { get; set; }

        [Required(ErrorMessage = "Informe o troco final")]
        [MinLength(0, ErrorMessage = "O troco não pode ser negativo")]
        public decimal EndValue { get; set; }
    }
}