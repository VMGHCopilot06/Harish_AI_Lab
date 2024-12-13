using Microsoft.EntityFrameworkCore;

namespace VehicleInsuranceAPI.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<VehicleInsuranceQuote> VehicleInsuranceQuotes { get; set; }
    }
}