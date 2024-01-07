using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using cse355.Models;

namespace cse355.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=MUZLAC; database=Database_Project; Integrated Security=true");
            }
        }
        public DbSet<cse355.Models.Company> Company { get; set; } = default!;
        public DbSet<cse355.Models.Product> Product { get; set; } = default!;
    }
}
