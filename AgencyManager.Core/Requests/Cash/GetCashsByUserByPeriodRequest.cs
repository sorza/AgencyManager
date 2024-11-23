namespace AgencyManager.Core.Requests.Cash
{
    public class GetCashsByUserRequest : PagedRequest
    {
        public string Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}