using apiAS.Domain.Entities;

namespace apiAS.Domain.Intefaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        void Update(Sale entity, Product newProduct = null);
    }
}