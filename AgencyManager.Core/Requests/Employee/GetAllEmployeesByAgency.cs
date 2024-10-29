namespace AgencyManager.Core.Requests.Employee
{
    public class GetAllEmployeesByAgencyId : Request
    {
        public int AgencyId { get; set; }
    }
}