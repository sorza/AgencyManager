using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Position
{
    public class CreatePositionRequest : Request
    {
        [Required(ErrorMessage = "Descrição do cargo inválida.")]
        [MinLength(3, ErrorMessage = "O cargo deve ter no mínimo 3 caracteres")]
        [MaxLength(70, ErrorMessage = "O cargo deve ter no máximo 70 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe as responsabilidades do cargo")]
        [MinLength(3, ErrorMessage = "As responsabilidades devem conter no mínimo 10 caracteres")]
        [MaxLength(70, ErrorMessage = "As responsabilidades devem conter no máximo 500 caracteres")]
        public string Responsabilities { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o salário")]        
        [Range(0, 20000, ErrorMessage = "O salário deve estar entre R$ 0 a R$ 20.000,00")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Informe a agência")]
        public int AgencyId { get; set; }        
    }
}