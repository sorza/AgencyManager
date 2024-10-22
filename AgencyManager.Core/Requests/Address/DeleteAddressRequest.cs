using Flunt.Validations;

namespace AgencyManager.Core.Requests.Address
{
    public class DeleteAddressRequest : Request
    {
        public int Id { get; set; }
        
        public bool Validate()
        {
            AddNotifications(new Contract<DeleteAddressRequest>()
                .Requires()
                .IsGreaterThan(Id, 0, "Id", "O ID deve ser maior que zero.")
            );

            return !Notifications.Any();
        }
    }
}
