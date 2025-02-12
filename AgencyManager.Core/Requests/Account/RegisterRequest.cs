using AgencyManager.Core.Common.CustomDataValidations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Core.Requests.Account
{
    public class RegisterRequest : Request
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = string.Empty;

        [PasswordPropertyText]
        [Required(ErrorMessage = "Senha inválida.")]        
        public string Password { get; set; } = string.Empty;

        [ComparePasswords("Password")]
        public string RePassword { get; set; } = string.Empty;
    }
}
