using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataBaseContext context;

        public ProductRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return context.Products
                .AsNoTracking()
                .ToList();
        }

        public Product GetProductByCode(long code)
        {
            return context.Products
                .AsNoTracking()
                .Where(p => p.Code == code)
                .FirstOrDefault();
        }
    }
}