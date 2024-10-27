namespace AgencyManager.Core.Requests.VirtualSale
{
    public class GetVirtualSalesByCash : PagedRequest
    {
        public Guid CashId { get; set; }
    }
}