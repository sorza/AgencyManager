using Microsoft.AspNetCore.Identity;

namespace AgencyManager.Api.Models
{
    public class User : IdentityUser<int>
    {
        public List<IdentityRole<int>>? Roles  { get; set; }
    }
}
