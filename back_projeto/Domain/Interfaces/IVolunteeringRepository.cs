using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVolunteeringRepository : IBaseRepository<Volunteering>
    {
        Task CreateAsync(Volunteering entity, IList<Responsibility> responsibilities, IList<Benefit> benefits);
    }
}