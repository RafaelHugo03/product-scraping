using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductByCode(long code);
        void Add(Product product);
    }
}