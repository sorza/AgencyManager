
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Locality : Entity
    {
        public Locality(string city, string state)
        {            
            City = city;
            State = state;
        }

        public string City {  get; private set; }
        public string State { get; private set; }
    }
}