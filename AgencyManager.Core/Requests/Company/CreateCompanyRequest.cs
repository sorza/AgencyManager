using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Contact;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Company
{
    public class CreateCompanyRequest : Request
    {
        [Required(ErrorMessage = "Razão Social Inválida.")]
        [MaxLength(60, ErrorMessage = "A Razão Social deve conter no máximo 60 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome fantasia inválido.")]
        [MaxLength(60, ErrorMessage = "O nome fantasia deve conter no máximo 60 caracteres")]
        public string TradingName { get; set; } = string.Empty;

        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter 14 dígitos númericos")]
        public string Cnpj { get; set; } = string.Empty;

        [Required(ErrorMessage ="Endereço inválido")]
        public CreateAddressRequest Address { get; set; }  = new();
        public IList<CreateContactRequest>? Contacts { get; set; } = [];
        public string? Logo { get; set; }
    }
}