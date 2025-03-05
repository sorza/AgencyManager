using System.ComponentModel.DataAnnotations;
using AgencyManager.Core.Common.CustomValidations;
using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Contact;

namespace AgencyManager.Core.Requests.Employee
{
    public class CreateEmployeeRequest : Request
    {       
        [Required(ErrorMessage = "Nome inválido.")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo 100 letras")]
        [MinLength(5, ErrorMessage = "O nome deve conter no mínimo 5 letras")]
        public string Name { get;  set; } = string.Empty;

        [MaxLength(11, ErrorMessage = "O CPF deve conter 11 dígitos")]
        [MinLength(11, ErrorMessage = "O CPF deve conter 11 dígitos")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos númericos")]
        public string Cpf { get; set; } = string.Empty;

        [MaxLength(14, ErrorMessage = "O RG deve conter no máximo 14 dígitos")]
        [MinLength(4, ErrorMessage = "O RG deve conter no mínimo 4 dígitos")]
        public string Rg { get; set; } = string.Empty;
       
        [AgeToHire]
        public DateTime? BirthDay { get; set; }

        [Required]
        public CreateAddressRequest Address { get; set; } = new();
       
        public int AgencyId { get; set; }

        [ValidPosition]
        public int PositionId { get; set; }

        public IList<CreateContactRequest?> Contacts { get; set; } = [];
       
        [ContractDate]
        public DateTime? DateHire { get; set; }

    }
}