using Flunt.Validations;

namespace AgencyManager.Core.Models.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string zipCode, string street, string number, string neighborhood, string city, string state, string? complement)
        {
            AddNotifications(new Contract<Address>().Requires()               
                .Matches(zipCode, @"^\d{8}$", "ZipCode", "O CEP deve conter 8 dígitos númericos.")

                .IsNotNullOrEmpty(street,"Street","Logradouro inválido.")         
                .IsLowerThan(street, 100, "Street","O Logradouro deve ter no máximo 100 caracteres")
               
                .Matches(number, @"^\d+$", "Number", "O campo deve conter apenas números.")
                .IsLowerThan(number, 7, "Number","O número deve ter no máximo 7 dígitos")

                .IsNotNullOrEmpty(neighborhood,"Neighborhood","Bairro inválido.")
                .IsGreaterThan(neighborhood, 3, "Neighborhood","O bairro deve ter no mínimo 3 caracteres")
                .IsLowerThan(neighborhood, 70, "Neighborhood","O Bairro deve ter no máximo 70 caracteres")

                .IsNotNullOrEmpty(city,"City","Cidade inválida.")
                .IsLowerThan(city, 100, "City","A cidade deve ter no máximo 70 caracteres")
                .IsGreaterThan(city, 3, "City","A cidade deve ter no mínimo 3 caracteres")
                
                .Matches(state, "^[a-zA-Z]{2}$", "State", "O Estado deve conter 2 dígitos alfabéticos.")

                .IsLowerThan(complement, 50, "Complement","O complemento deve ter no máximo 50 dígitos")
            );

            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement;
        }

        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string? Complement { get; private set; }
    }
}