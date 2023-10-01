using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Intarfaces
{
    public interface IVoluntariadoRepository : IBaseRepository<Volutariado>
    {
        Task CreateAsync(Volutariado entity, Instituto instituto);
    }
}