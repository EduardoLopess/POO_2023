using ap2.Domain.Entities;

namespace ap2.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
         void Update(Product entity);
    }
}