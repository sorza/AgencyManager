using Flunt.Validations;

namespace AgencyManager.Core.Requests.Address
{
    public class UpdateAddressRequest : Request
    {
        public int Id { get; set; }
        public string ZipCode { get;  set; } = string.Empty;
        public string Street { get;  set; } = string.Empty;
        public string Number { get;  set; } = string.Empty;
        public string Neighborhood { get;  set; } = string.Empty;
        public string City { get;  set; } = string.Empty;
        public string State { get;  set; } = string.Empty;
        public string? Complement { get;  set; } = string.Empty;

        public void Validate()
        {
            AddNotifications(new Contract<UpdateAddressRequest>()
                .Requires()
                .IsGreaterThan(Id, 0, "Id", "O ID deve ser maior que zero.")
                .Matches(ZipCode, @"^\d{8}$", "ZipCode", "O CEP deve conter 8 dígitos numéricos.")
                .IsNotNullOrEmpty(Street, "Street", "Logradouro inválido.")
                .IsLowerThan(Street, 100, "Street", "O Logradouro deve ter no máximo 100 caracteres")
                .Matches(Number, @"^\d+$", "Number", "O campo deve conter apenas números.")
                .IsLowerThan(Number, 7, "Number", "O número deve ter no máximo 7 dígitos")
                .IsNotNullOrEmpty(Neighborhood, "Neighborhood", "Bairro inválido.")
                .IsGreaterThan(Neighborhood, 3, "Neighborhood", "O bairro deve ter no mínimo 3 caracteres")
                .IsLowerThan(Neighborhood, 70, "Neighborhood", "O Bairro deve ter no máximo 70 caracteres")
                .IsNotNullOrEmpty(City, "City", "Cidade inválida.")
                .IsLowerOrEqualsThan(City, 100, "City", "A cidade deve ter no máximo 100 caracteres")
                .IsGreaterOrEqualsThan(City, 3, "City", "A cidade deve ter no mínimo 3 caracteres")
                .Matches(State, "^[a-zA-Z]{2}$", "State", "O Estado deve conter 2 dígitos alfabéticos.")
                .IsLowerThan(Complement, 50, "Complement", "O complemento deve ter no máximo 50 caracteres")
            );
        }
    }
}