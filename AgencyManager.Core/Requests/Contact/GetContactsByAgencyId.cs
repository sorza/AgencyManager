namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByAgencyId : PagedRequest
    {
        public int AgencyId { get; set; }
    }
}