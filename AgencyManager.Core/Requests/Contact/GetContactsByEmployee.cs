namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByEmployee : PagedRequest
    {
        public Guid EmplooyeeId { get; set; }
    }
}