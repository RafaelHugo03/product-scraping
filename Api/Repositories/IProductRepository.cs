using Api.Entities;
using Api.Viewmodels;

namespace Api.Repositories
{
    public interface IProductRepository
    {
        PagedResult<Product> GetAllProducts(int pageIndex, int pageSize);
        Product GetProductByCode(long code);
        Task AddAsync(Product product);
    }
}