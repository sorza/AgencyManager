using AgencyManager.Core.Enums;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.ContractService
{
    public class CreateContractServiceRequest : Request
    {
        public int AgencyId { get; set; }
        public int CompanyId { get; set; }
        public EServiceType ServiceType { get; set; }
        public decimal Comission { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; private set; }
        public void Validate()
        {
             AddNotifications(new Contract<CreateContractServiceRequest>().Requires()   
                .IsLowerOrEqualsThan(Comission, 50, "Comission", "A comissão não pode ser maior que 50%" )
                .IsGreaterOrEqualsThan(Comission, 1, "Comission", "A comissão não pode ser menor que 1%" )              
                .IsGreaterThan(AgencyId, 0, "Identificador de agência inválido")
                .IsGreaterThan(CompanyId, 0, "Identificador de empresa inválido")
            );
        }
    }
}