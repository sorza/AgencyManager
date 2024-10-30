using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Models.Entities
{
    public class ContractService : Entity
    {
        public ContractService()
        {
            
        }
        public ContractService(int agencyId, int companyId, EServiceType serviceType, decimal comission, DateTime? startDate)
        {       
            AgencyId = agencyId;           
            CompanyId = companyId;
            ServiceType = serviceType;            
            Comission = comission;
            StartDate = startDate ?? DateTime.Now;
        }

        public bool Active { get; private set; } = true;
        public int AgencyId { get; private set; }
        public virtual Agency? Agency { get; private set; }
        public int CompanyId { get; private set; }
        public virtual Company? Company { get; private set; }
        public EServiceType ServiceType { get; private set; } = EServiceType.Ticket;
        public decimal Comission { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

    }
}