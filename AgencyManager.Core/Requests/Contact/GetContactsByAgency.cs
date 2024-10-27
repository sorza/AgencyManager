namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByAgency : PagedRequest
    {
        public Guid AgencyId { get; set; }
    }
}