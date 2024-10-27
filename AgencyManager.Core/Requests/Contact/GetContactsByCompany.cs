namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByCompany : PagedRequest
    {
        public Guid ComapanyId { get; set; }
    }
}