namespace AgencyManager.Core.Requests.ContractService
{
    public class GetAllContractsByAgencyRequest : PagedRequest
    {
        public Guid AgencyId { get; set; }
    }
}