using ap2.Domain.Entities;

namespace ap2.Domain.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        void Update(Sale entity, Product newProduct = null);
    }
}