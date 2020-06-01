using Microsoft.AspNetCore.Identity;

namespace WebAPI.DAL.Entities
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
    }
}