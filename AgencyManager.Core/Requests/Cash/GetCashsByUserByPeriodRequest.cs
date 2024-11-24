namespace AgencyManager.Core.Requests.Cash
{
    public class GetCashsByUserByPeriodRequest : PagedRequest
    {
        public string Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}