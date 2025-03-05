using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities.ValueObjects;

namespace AgencyManager.Core.Responses.DTOs
{
    public class ContractDto
    {
        public int Id { get; set; }
        public bool Active { get; set; }       
        public int AgencyId { get; set; }
        public AgencyDto? Agency { get; set; }
        public int CompanyId { get; set; }   
        public CompanyDto? Company { get; set; }
        public EServiceType ServiceType { get; set; }      
        public decimal Comission { get; set; }      
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Boleto { get; set; }
        public bool DailyPayment { get; set; }
        public bool DailyComission { get; set; }
        public bool Nfe { get; set; }
        public NfeData? NfeData { get; set; }
    }
}
