namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByAgency : PagedRequest
    {
        public int AgencyId { get; set; }
    }
}