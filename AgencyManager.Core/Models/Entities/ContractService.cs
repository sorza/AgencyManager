using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities.ValueObjects;

namespace AgencyManager.Core.Models.Entities
{
    public class ContractService : Entity
    {
        public ContractService()
        {
            
        }
        public ContractService(int agencyId, int companyId, EServiceType serviceType, decimal comission, DateTime startDate, DateTime? endDate, bool dailyPayment, bool boleto, bool dailyComission, bool nfe, NfeData? nfeData )
        {       
            AgencyId = agencyId;           
            CompanyId = companyId;
            ServiceType = serviceType;            
            Comission = comission;
            StartDate = startDate;
            
            DailyPayment = dailyPayment;
            DailyComission = dailyComission;
            Boleto = boleto;
            Nfe = nfe;

            if(endDate is not null ) EndDate = endDate; 
            if(nfeData is not null) NfeData = nfeData; 

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
        public bool DailyPayment { get; private set; }
        public bool Boleto { get; private set; } 
        public bool DailyComission { get; private set; }
        public bool Nfe { get; private set; }         
        public virtual NfeData? NfeData { get; private set; }

    }
}