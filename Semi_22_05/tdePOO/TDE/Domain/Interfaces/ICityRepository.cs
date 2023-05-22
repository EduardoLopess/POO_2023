using TDE.Domain.Entities;

namespace TDE.Domain.Interfaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        void Create(City city);
    }
}