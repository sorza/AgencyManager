namespace AgencyManager.Core.Requests.Position
{
    public class GetPositionsByAgencyIdRequest : PagedRequest
    {
        public int AgencyId { get; set; }
    }
}