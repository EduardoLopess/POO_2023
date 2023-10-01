using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task CreateAsync(Usuario entity, Endereco endereco);
    }
}