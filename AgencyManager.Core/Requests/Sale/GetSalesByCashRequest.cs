namespace AgencyManager.Core.Requests.Sale
{
    public class GetSalesByCashRequest : PagedRequest
    {
        public int CashId { get; set; }
    }
}