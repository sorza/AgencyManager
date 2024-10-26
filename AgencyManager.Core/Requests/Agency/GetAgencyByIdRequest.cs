namespace AgencyManager.Core.Requests.Agency
{
    public class GetAgencyByIdRequest : Request
    {
         public Guid Id { get; set; }
    }
}