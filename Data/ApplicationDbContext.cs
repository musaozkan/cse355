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
        public DbSet<cse355.Models.Company> Company { get; set; } = default!;
        public DbSet<cse355.Models.Product> Product { get; set; } = default!;
    }
}
