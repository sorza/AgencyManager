using AgencyManager.Core.Requests;

namespace AgencyManager.Tests.Core.Requests.Contact
{
    public class DeleteConctactRequest : Request
    {
        public Guid Id { get; set; }
    }
}