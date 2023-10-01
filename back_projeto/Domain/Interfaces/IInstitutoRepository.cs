using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInstitutoRepository : IBaseRepository<Instituto>
    {
        Task CreateAsync(Instituto entity, Endereco endereco);
    }
}