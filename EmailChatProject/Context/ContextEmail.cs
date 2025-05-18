using EmailChatProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmailChatProject.Context
{
    public class ContextEmail : IdentityDbContext<AppUser>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-LJIBOKJ;initial Catalog=EmailChatProject; integrated security=true; trust server certificate=true");
        }

        public DbSet<Message> messages { get; set; }

    }
}
