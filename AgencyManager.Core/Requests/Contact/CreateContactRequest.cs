using System.ComponentModel.DataAnnotations;
using AgencyManager.Core.Common.CustomValidations;
using AgencyManager.Core.Enums;

namespace AgencyManager.Core.Requests.Contact
{
    public class CreateContactRequest : Request
    {
        [Required(ErrorMessage = "O tipo de contato é obrigatório")]
        public EContactType ContactType { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]        
        [MaxLength(120, ErrorMessage = "O contato deve ter no máximo 120 caracteres")]
        [MinLength(7, ErrorMessage = "O contato deve ter no mínimo 7 caracteres")]
        [ContactValidation]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "O departamento/setor é obrigatório")]
        [MaxLength(70, ErrorMessage = "O departamento/setor deve ter no máximo 70 caracteres")]
        [MinLength(2, ErrorMessage = "O departamento/setor deve ter no mínimo 2 caracteres")]
        public string Departament { get; set; } = string.Empty;
        public string? Responsible { get; set; } = string.Empty;
        public int? AgencyId { get; set; }
        public int? CompanyId { get; set; }
        public int? EmployeeId { get; set; }        
    }
}