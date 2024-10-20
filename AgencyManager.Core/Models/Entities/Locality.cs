
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Locality : Entity
    {
        public Locality(string city, string state)
        {
            AddNotifications(new Contract<Locality>().Requires()
            
                .IsNotNullOrEmpty(city,"City","Cidade inválida.")
                .IsLowerOrEqualsThan(city, 100, "City","A cidade deve ter no máximo 70 caracteres")
                .IsGreaterOrEqualsThan(city, 3, "City","A cidade deve ter no mínimo 3 caracteres")
                
                .Matches(state, "^[a-zA-Z]{2}$", "State", "O Estado deve conter 2 dígitos alfabéticos.")
            );

            City = city;
            State = state;
        }

        public string City {  get; private set; }
        public string State { get; private set; }

        public override bool Equals(object? obj)
        {       
            if (obj == null) return false;

            var locality = (Locality)obj;

            return City == locality.City &&
                   State == locality.State;        
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(City, State);
        }
    }
}