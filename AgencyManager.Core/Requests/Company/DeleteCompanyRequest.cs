namespace AgencyManager.Core.Requests.Company
{
    public class DeleteCompanyRequest : Request
    {
        public Guid Id { get; set; }
    }
}