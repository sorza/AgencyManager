using System.ComponentModel.DataAnnotations;
using AgencyManager.Core.Common.CustomValidations;
using AgencyManager.Core.Requests.Address;

namespace AgencyManager.Core.Requests.Employee
{
    public class CreateEmployeeRequest : Request
    {       
        [Required(ErrorMessage = "Nome inválido.")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo 100 letras")]
        [MinLength(5, ErrorMessage = "O nome deve conter no mínimo 5 letras")]
        public string Name { get;  set; } = string.Empty;
        
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos númericos")]
        public string Cpf { get; set; } = string.Empty;

        [MaxLength(14, ErrorMessage = "O RG deve conter no máximo 14 dígitos")]
        [MinLength(4, ErrorMessage = "O RG deve conter no mínimo 4 dígitos")]
        public string Rg { get; set; } = string.Empty;

        [AgeToHire]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage ="Endereço inválido")]
        public CreateAddressRequest Address { get; set; } = null!;

        [Required(ErrorMessage ="Agência inválida")]
        public int AgencyId { get; set; }
        [Required(ErrorMessage = "Cargo inválido")]
        public int PositionId { get; set; }

        [Required(ErrorMessage ="Informe a data de contratação")]
        public DateTime DateHire { get; set; }            
      
    }
}