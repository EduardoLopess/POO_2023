using apiAS.Domain.Entities;

namespace apiAS.Domain.Intefaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        void Update(Client entity);
    }
}