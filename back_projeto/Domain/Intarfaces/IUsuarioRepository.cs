using Domain.Entities;

namespace Domain.Intarfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task CreateAsync(Usuario entity, Endereco endereco);

    }
}