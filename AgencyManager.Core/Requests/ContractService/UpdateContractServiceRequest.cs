using AgencyManager.Core.Enums;
using AgencyManager.Core.Requests.Nfe;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.ContractService
{
    public class UpdateContractServiceRequest : Request
    {
        public int Id { get; set; }
        public bool Active { get; set; }

        [Required(ErrorMessage = "Informe a agência")]
        public int AgencyId { get; set; }
        [Required(ErrorMessage = "Informe a empresa")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "O tipo de serviço é obrigatório")]
        public EServiceType ServiceType { get; set; }
        [Required(ErrorMessage = "Informe o valor da comissão")]
        [Range(1.0, 50.0, ErrorMessage = "A comissão deve ser entre 1 a 50.")]
        public decimal Comission { get; set; }
        [Required(ErrorMessage = "Informe a data de início do contrato")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool DailyPayment { get; set; }
        public bool Boleto { get; set; }
        public bool DailyComission { get; set; }
        public bool Nfe { get; set; }
        public UpdateNfeDataRequest NfeData { get; set; } = new();
    }
}