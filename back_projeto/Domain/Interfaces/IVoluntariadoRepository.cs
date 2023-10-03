using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Intarfaces
{
    public interface IVoluntariadoRepository : IBaseRepository<Voluntariado>
    {
        Task CreateAsync(Voluntariado entity, Instituto instituto);
    }
}