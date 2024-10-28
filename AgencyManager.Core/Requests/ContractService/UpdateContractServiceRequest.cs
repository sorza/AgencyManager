using AgencyManager.Core.Enums;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.ContractService
{
    public class UpdateContractServiceRequest : Request
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public Guid AgencyId { get; set; }
        public Guid CompanyId { get; set; }
        public EServiceType ServiceType { get; set; }
        public decimal Comission { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; private set; }
        public void Validate()
        {
             AddNotifications(new Contract<UpdateContractServiceRequest>().Requires()   
                .IsLowerOrEqualsThan(Comission, 50, "Comission", "A comissão não pode ser maior que 50%" )
                .IsGreaterOrEqualsThan(Comission, 1, "Comission", "A comissão não pode ser menor que 1%" )               
                .AreNotEquals(AgencyId, Guid.Empty, "Identificador de agência inválido")
                .AreNotEquals(CompanyId, Guid.Empty, "Identificador de empresa inválido")
                .AreNotEquals(Id, Guid.Empty, "O Identificador do contrato é inválido")
            );
        }
    }
}