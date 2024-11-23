namespace AgencyManager.Core.Requests.Cash
{
    public class GetCashsByAgencyByPeriodRequest : PagedRequest
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}