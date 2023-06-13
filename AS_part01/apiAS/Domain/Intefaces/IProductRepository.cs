using apiAS.Domain.Entities;

namespace apiAS.Domain.Intefaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        void Update(Product entity);
    }
}