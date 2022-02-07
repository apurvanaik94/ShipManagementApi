using Microsoft.EntityFrameworkCore;
using ShipManagementApi.Entities;

namespace ShipManagementApi.DAL
{
    public class DataContext : DbContext
    {
        private readonly DbContextOptions _options;
        public DataContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ShipDb");
        }
        public DbSet<Ship> Ships { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}