using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OCWebOverview.Data.Entities;

namespace OCWebOverview.Data.Database
{
    public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Werknemer> Werknemers { get; set; }
        public DbSet<Gemeente> Gemeentes { get; set; }
    }
}
