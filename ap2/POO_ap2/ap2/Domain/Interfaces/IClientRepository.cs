using ap2.Domain.Entities;

namespace ap2.Domain.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        void Update(Client entity);
    }
}