using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Position
{
    public class UpdatePositionRequest : Request
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Descrição do cargo inválida.")]
        [MinLength(3, ErrorMessage = "O cargo deve ter no mínimo 3 caracteres")]
        [MaxLength(70, ErrorMessage = "O cargo deve ter no máximo 70 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe as responsabilidades do cargo")]
        [MinLength(10, ErrorMessage = "As responsabilidades devem conter no mínimo 10 caracteres")]
        [MaxLength(500, ErrorMessage = "As responsabilidades devem conter no máximo 500 caracteres")]
        public string Responsabilities { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o salário")]
        [Range(0, 20000, ErrorMessage = "O salário deve estar entre R$ 0 a R$ 20000")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Informe a agência")]
        public int AgencyId { get; set; }
    }
}