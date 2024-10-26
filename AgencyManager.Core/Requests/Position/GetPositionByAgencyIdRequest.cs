namespace AgencyManager.Core.Requests.Position
{
    public class GetPositionsByAgencyIdRequest : PagedRequest
    {
        public Guid AgencyId { get; set; }
    }
}