using AgencyManager.Core.Requests.Address;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Nfe
{
    public class UpdateNfeDataRequest
    {
        [Required(ErrorMessage = "Razão Social Inválida.")]
        [MaxLength(60, ErrorMessage = "A Razão Social deve conter no máximo 60 caracteres")]
        public string Name { get; set; } = string.Empty;

        [StringLength(14, ErrorMessage = "O CNPJ deve conter 14 caracteres", MinimumLength = 14)]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter 14 dígitos númericos")]
        public string Cnpj { get; set; } = string.Empty;

        public string? Ie { get; set; }

        [Required]
        public UpdateAddressRequest Address { get; set; } = new();
    }
}
