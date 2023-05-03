using EmailSenderMvc.Models.Domains;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EmailSenderMvc.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Email> Emails { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}