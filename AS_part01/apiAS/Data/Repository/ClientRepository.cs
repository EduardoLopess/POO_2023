using apiAS.Domain.Entities;
using apiAS.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace apiAS.Data.Repository
{
    public class ClientRepository : IClientRepository
    {

        private readonly DbContext _context;
        public ClientRepository()
        {
            _context = new DataContext();
        }

        public void Create(Client entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IList<Client> GetAll()
        {
            return _context.Set<Client>().ToList();
        }

        public Client GetById(int entityId)
        {
            return _context.Set<Client>()
                .SingleOrDefault(c => c.IdClient == entityId);
        }

        public void Update(Client entity)
        {
            _context.Set<Client>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            _context.Set<Client>().Remove(GetById(entityId));
            _context.SaveChanges();
        }
    }
}