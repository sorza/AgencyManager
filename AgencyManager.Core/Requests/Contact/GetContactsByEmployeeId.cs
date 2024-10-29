namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByEmployeeId : PagedRequest
    {
        public int EmplooyeeId { get; set; }
    }
}