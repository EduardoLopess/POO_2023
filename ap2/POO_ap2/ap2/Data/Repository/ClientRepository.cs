using ap2.Domain.Entities;
using ap2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ap2.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbContext context;
        public ClientRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        public void Create(Client entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public IList<Client> GetAll()
        {
            return context.Set<Client>().ToList();
        }

        public Client GetById(int entityId)
        {
            return context.Set<Client>()
                .SingleOrDefault(c => c.ClientId == entityId);
        }

        public void Update(Client entity)
        {
            context.Set<Client>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            context.Set<Client>().Remove(GetById(entityId));
            context.SaveChanges();
        }
    }
}