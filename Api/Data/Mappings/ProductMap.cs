using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Code).HasColumnName("code")
                .HasColumnType("int8");
                
            builder.Property(p => p.BarCode).HasColumnName("bar_code")
                .HasColumnType("varchar");
                
            builder.Property(p => p.Imported_at).HasColumnName("imported_at")
                .HasColumnType("timestamp without time zone");

            builder.Property(p => p.Status).HasColumnName("status")
                .HasColumnType("smallint");

            builder.Property(p => p.Url).HasColumnName("url")
                .HasColumnType("varchar");

            builder.Property(p => p.ProductName).HasColumnName("product_name")
                .HasColumnType("varchar");

            builder.Property(p => p.Quantity).HasColumnName("quantity")
                .HasColumnType("varchar");
            
            builder.Property(p => p.Packaging).HasColumnName("packaging")
                .HasColumnType("varchar");

            builder.Property(p => p.Brands).HasColumnName("brands")
                .HasColumnType("varchar");

            builder.Property(p => p.ImageUrl).HasColumnName("image-url")
                .HasColumnType("varchar");

            builder.Property(p => p.Categories).HasColumnName("categories")
                .HasColumnType("varchar");
        }
    }
}