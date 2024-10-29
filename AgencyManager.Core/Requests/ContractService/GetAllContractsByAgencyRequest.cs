namespace AgencyManager.Core.Requests.ContractService
{
    public class GetAllContractsByAgencyRequest : PagedRequest
    {
        public int AgencyId { get; set; }
    }
}