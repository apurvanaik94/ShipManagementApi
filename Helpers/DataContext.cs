using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShipManagementApi.Entities;

namespace ShipManagementApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("ShipDb");
        }

        public DbSet<Ship> Ships { get; set; }
    }
}