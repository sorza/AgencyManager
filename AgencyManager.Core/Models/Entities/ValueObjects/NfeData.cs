namespace AgencyManager.Core.Models.Entities.ValueObjects
{
    public class NfeData : ValueObject
    {    
        public NfeData(string name, string cnpj, string? ie, string zipCode, string street, string number, string neighborhood, string city, string state, string? complement)
        {
            Name = name;
            Cnpj = cnpj;
            Ie = ie ?? string.Empty;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement ?? string.Empty;
        }

        public string Name { get; private set; } 
        public string Cnpj { get; private set; }
        public string? Ie { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string? Complement { get; private set; }
    }
}
