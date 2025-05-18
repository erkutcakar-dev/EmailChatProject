using Microsoft.AspNetCore.Identity;

namespace EmailChatProject.Entities
{
    public class AppUser :IdentityUser
    {
        public string? ProfileImageURL { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
  

    }
}
