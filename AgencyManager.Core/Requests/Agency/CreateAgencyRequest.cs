using AgencyManager.Core.Requests.Address;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Agency
{
    public class CreateAgencyRequest : Request
    {
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(60, ErrorMessage = "A descrição deve ter no máximo 60 caracteres")]
        [MinLength(2, ErrorMessage = "A descrição deve ter no mínimo 2 caracteres")]
        public string Description { get;  set; } = string.Empty;

        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter 14 dígitos númericos")]
        public string Cnpj { get;  set; } = string.Empty;
        [Required(ErrorMessage = "O endereço é obrigatório")]
        public CreateAddressRequest Address { get; set; } = new();
        public string? Photo { get; private set; }
    }
}