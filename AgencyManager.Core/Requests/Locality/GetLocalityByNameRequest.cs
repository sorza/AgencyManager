namespace AgencyManager.Core.Requests.Locality
{
    public class GetLocalityByNameRequest : Request
    {
        public string Locality { get; set; } = string.Empty;
    }
}