using Microsoft.AspNetCore.Identity;

namespace AgencyManager.Data.Models
{
    internal class User : IdentityUser<long>
    {
        public List<IdentityRole<long>>? Roles { get; set; }
    }
}
