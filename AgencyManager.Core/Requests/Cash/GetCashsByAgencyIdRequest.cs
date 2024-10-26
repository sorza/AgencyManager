namespace AgencyManager.Core.Requests.Cash
{
    public class GetCashsByAgencyIdRequest : PagedRequest
    {
        public Guid Id { get; set; }
    }
}