using Api.Entities;
using Api.Repositories;
using Api.Viewmodels;
using Api.Data;
using Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataBaseContext context;

        public ProductRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public PagedResult<Product> GetAllProducts(int pageIndex, int pageSize)
        {
            return context.Products
                .AsNoTracking()
                .AsQueryable()
                .GetPaged<Product>(pageIndex, pageSize);
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