using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Address
{
    public class UpdateAddressRequest : Request
    {
        [Required(ErrorMessage = "O Cep é obrigatório")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter 8 dígitos numéricos")]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "O logradouro é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Logradouro deve ter no máximo 100 caracteres")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Número é obrigatório")]
        [RegularExpression(@"^\d+$", ErrorMessage = "O campo deve conter apenas números")]
        [MaxLength(7, ErrorMessage = "O número deve ter no máximo 7 dígitos")]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        [MaxLength(70, ErrorMessage = "O Bairro deve ter no máximo 70 caracteres")]
        [MinLength(3, ErrorMessage = "O bairro deve ter no mínimo 3 caracteres")]
        public string Neighborhood { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Cidade é obrigatória")]
        [MaxLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres")]
        [MinLength(3, ErrorMessage = "A cidade deve ter no mínimo 3 caracteres")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "A UF é obrigatória")]
        [RegularExpression("^[a-zA-Z]{2}$", ErrorMessage = "O Estado deve conter 2 dígitos alfabéticos")]
        public string State { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "O complemento deve ter no máximo 50 caracteres")]
        public string? Complement { get; set; } = string.Empty;
    }
}