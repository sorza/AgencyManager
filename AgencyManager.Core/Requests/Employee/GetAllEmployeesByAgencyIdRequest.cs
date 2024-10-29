namespace AgencyManager.Core.Requests.Employee
{
    public class GetAllEmployeesByAgencyIdRequest : Request
    {
        public int AgencyId { get; set; }
    }
}