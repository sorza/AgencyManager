namespace AgencyManager.Core.Requests.Transaction
{
    public class GetTransactionsByCashIdRequest : PagedRequest
    {
        public int CashId { get; set; }
    }
}