using Microsoft.AspNetCore.Identity;

namespace OnlineNewsPaper.Data.Models
{
    public class User : IdentityUser
    {
        public ApplicationUser ApplicationUser { get; set; }
    }
}