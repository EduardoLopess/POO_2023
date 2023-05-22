using TDE.Domain.Entities;

namespace TDE.Domain.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        void Create(Person person, int cityId);
    }
}