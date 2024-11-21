using AgencyManager.Core.Enums;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.ContractService
{
    public class CreateContractServiceRequest : Request
    {
        [Required(ErrorMessage ="Informe a agência")]
        public int AgencyId { get; set; }
        [Required(ErrorMessage = "Informe a empresa")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "O tipo de serviço é obrigatório")]
        public EServiceType ServiceType { get; set; }
        [Required(ErrorMessage = "Informe o valor da comissão")]
        [MaxLength(50, ErrorMessage ="A comissão não pode ser maior que 50%")]
        [MinLength(1, ErrorMessage = "A comissão não pode ser menor que 1%")]
        public decimal Comission { get; set; }
        [Required(ErrorMessage ="Informe a data de início do contrato")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; private set; }       
    }
}