namespace AgencyManager.Core.Requests.Cash
{
    public class GetCashsByAgencyIdRequest : PagedRequest
    {
        public int Id { get; set; }
    }
}