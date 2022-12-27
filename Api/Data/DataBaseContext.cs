using Api.Entities;
using Api.Data.Mappings;
using Microsoft.EntityFrameworkCore;
namespace Api.Data
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