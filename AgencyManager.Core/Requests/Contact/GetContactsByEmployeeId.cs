namespace AgencyManager.Core.Requests.Contact
{
    public class GetContactsByEmployeeId : PagedRequest
    {
        public int EmployeeId { get; set; }
    }
}