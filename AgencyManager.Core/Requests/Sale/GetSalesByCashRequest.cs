namespace AgencyManager.Core.Requests.Sale
{
    public class GetSalesByCashRequest : PagedRequest
    {
        public Guid CashId { get; set; }
    }
}