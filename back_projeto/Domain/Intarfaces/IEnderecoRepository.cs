using Domain.Entities;

namespace Domain.Intarfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task CreateAsync(Endereco entity, int usuarioId);
    }
}