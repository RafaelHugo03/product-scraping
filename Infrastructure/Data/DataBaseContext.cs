using Domain.Entities;
using Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}