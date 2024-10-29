namespace AgencyManager.Core.Requests.VirtualSale
{
    public class GetVirtualSalesByCashIdRequest : PagedRequest
    {
        public int CashId { get; set; }
    }
}