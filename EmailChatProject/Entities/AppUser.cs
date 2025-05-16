using Microsoft.AspNetCore.Identity;

namespace EmailChatProject.Entities
{
    public class AppUser :IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
  

    }
}
