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
            // in memory database used for simplicity, change to a real db for production applications
            options.UseInMemoryDatabase("TestDb");
        }

        public DbSet<Ship> Ships { get; set; }
    }
}