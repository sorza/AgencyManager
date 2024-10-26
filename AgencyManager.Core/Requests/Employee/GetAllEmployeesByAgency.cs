namespace AgencyManager.Core.Requests.Employee
{
    public class GetAllEmployeesByAgencyId : Request
    {
        public Guid AgencyId { get; set; }
    }
}