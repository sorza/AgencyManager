namespace AgencyManager.Core.Requests.Employee
{
    public class GetAllEmployeesByAgencyIdRequest : PagedRequest
    {
        public int AgencyId { get; set; }
    }
}