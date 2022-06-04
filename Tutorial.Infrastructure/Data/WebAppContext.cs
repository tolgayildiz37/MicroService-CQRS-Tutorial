using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tutorial.Core.Entities;

namespace Tutorial.Infrastructure.Data
{
    public class WebAppContext : IdentityDbContext<AppUser>
    {
        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
