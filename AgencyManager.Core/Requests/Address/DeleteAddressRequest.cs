using Flunt.Validations;

namespace AgencyManager.Core.Requests.Address
{
    public class DeleteAddressRequest : Request
    {
        public int Id { get; set; }
        
        public void Validate()
        {
            AddNotifications(new Contract<DeleteAddressRequest>()
                .Requires()
                .IsGreaterThan(Id, 0, "Id", "O ID deve ser maior que zero.")
            );
        }
    }
}
