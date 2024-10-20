using AgencyManager.Core.Enums;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class ServiceContract : Entity
    {
        public ServiceContract(int agencyId, int companyId, EServiceType serviceType, decimal comission, DateTime? startDate)
        {            
            
            AddNotifications(new Contract<ServiceContract>().Requires()   
                .IsLowerOrEqualsThan(comission, 50, "Comission", "A comissão não pode ser maior que 50%" )
                .IsGreaterOrEqualsThan(comission, 1, "Comission", "A comissão não pode ser menor que 1%" )
            );

            if(Enum.IsDefined(typeof(EServiceType), serviceType)) ServiceType = serviceType;
            else AddNotification("ServiceType", "Serviço Inválido");            

            AgencyId = agencyId;           
            CompanyId = companyId;
            
            Comission = comission;
            StartDate = startDate ?? DateTime.Now;
        }

        public bool Active { get; private set; }
        public int AgencyId { get; private set; }
        public virtual Agency? Agency { get; private set; }
        public int CompanyId { get; private set; }
        public virtual Company? Company { get; private set; }
        public EServiceType ServiceType { get; private set; }
        public decimal Comission { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

    }
}