namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByEmployee : PagedRequest
    {
        public int EmplooyeeId { get; set; }
    }
}