using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Locality
{
    public class UpdateLocalityRequest : Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a cidade")]
        [MinLength(3, ErrorMessage = "A cidade deve ter no mínimo 3 caracteres")]
        [MaxLength(70, ErrorMessage = "A cidade deve ter no máximo 70 caracteres")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o estado")]
        [RegularExpression("^[a-zA-Z]{2}$", ErrorMessage = "O Estado deve conter 2 dígitos alfabéticos.")]
        public string State { get; set; } = string.Empty;
    }
}