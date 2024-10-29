namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByCompany : PagedRequest
    {
        public int ComapanyId { get; set; }
    }
}