using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DbContext _context;
        public AutorRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(Autor entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IList<Autor> GetAll()
        {
            return _context.Set<Autor>()
                .Include(l => l.Livros).ToList();
        }

        public Autor GetById(int entityId)
        {
            return _context.Set<Autor>()
                .Include(l => l.Livros)
                .SingleOrDefault(i => i.Id == entityId);
        }

        public void Delete(int entityId)
        {
            _context.Set<Autor>().Remove(GetById(entityId));
            _context.SaveChanges();
        }

        public void Update(Autor entity)
        {
            _context.Set<Autor>().Update(entity);
            _context.SaveChanges();
        }
    }
}