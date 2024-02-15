using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OCWebOverview.Data.Entities;

namespace OCWebOverview.Data.Database
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Werknemer> Werknemers { get; set; }
        public DbSet<Gemeente> Gemeentes { get; set; }
    }
}
