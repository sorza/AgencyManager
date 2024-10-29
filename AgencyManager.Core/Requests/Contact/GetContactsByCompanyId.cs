namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByCompanyId : PagedRequest
    {
        public int ComapanyId { get; set; }
    }
}