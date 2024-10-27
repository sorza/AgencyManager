namespace AgencyManager.Core.Requests.Transaction
{
    public class GetTransactionsByCashId : PagedRequest
    {
        public Guid CashId { get; set; }
    }
}