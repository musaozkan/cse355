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
                optionsBuilder.UseSqlServer("data source=ACER-NITRO-5; database=Database_Project; Integrated Security=true");
            }
        }
        public DbSet<cse355.Models.Company> Company { get; set; } = default!;
        public DbSet<cse355.Models.Product> Product { get; set; } = default!;
        public DbSet<cse355.Models.Customer> Customer { get; set; } = default!;
        public DbSet<cse355.Models.Depot> Depot { get; set; } = default!;
        public DbSet<cse355.Models.Order> Order { get; set; } = default!;
        public DbSet<cse355.Models.Shipment> Shipment { get; set; } = default!;
        public DbSet<cse355.Models.Order_Quantities> Order_Quantities { get; set; } = default!;
        public DbSet<cse355.Models.Order_OrderedProduct> Order_OrderedProduct { get; set; } = default!;
        public DbSet<cse355.Models.ShipmentArrivalLocations> ShipmentArrivalLocations { get; set; } = default!;
        public DbSet<cse355.Models.Truck> Truck { get; set; } = default!;
        public DbSet<cse355.Models.TruckDeliveryRoutes> TruckDeliveryRoutes { get; set; } = default!;
    }
}
