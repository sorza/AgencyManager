namespace AgencyManager.Core.Requests.Locality
{
    public class GetLocalityByIdRequest : Request
    {
        public string Locality { get; set; } = string.Empty;
    }
}