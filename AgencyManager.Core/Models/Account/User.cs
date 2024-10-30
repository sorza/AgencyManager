using System.ComponentModel.DataAnnotations.Schema;

namespace AgencyManager.Core.Models.Account
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public bool isEmailConfirmed { get; set; }

        [NotMapped]
        public Dictionary<string, string> Claims { get; set; } = [];
    }
}