namespace AgencyManager.Core.Requests.Transaction
{
    public class GetTransactionsByCashId : PagedRequest
    {
        public int CashId { get; set; }
    }
}