using Flunt.Validations;

namespace AgencyManager.Core.Requests.Locality
{
    public class CreateLocalityRequest : Request
    {
        public string City {  get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        public void Validate()
        {            
            AddNotifications(new Contract<CreateLocalityRequest>().Requires()
            
                .IsNotNullOrEmpty(City,"City","Cidade inválida.")
                .IsLowerOrEqualsThan(City, 100, "City","A cidade deve ter no máximo 70 caracteres")
                .IsGreaterOrEqualsThan(City, 3, "City","A cidade deve ter no mínimo 3 caracteres")
                
                .Matches(State, "^[a-zA-Z]{2}$", "State", "O Estado deve conter 2 dígitos alfabéticos.")
            );
        }
    }
}