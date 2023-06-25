using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly DbContext _context;
        public EmprestimoRepository(DbContext context)
        {
            _context = context;
        }
        public void Create(Emprestimo entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IList<Emprestimo> GetAll()
        {
            return _context.Set<Emprestimo>()
                .Include(a => a.Usuario)
                .Include(l => l.Livro)
                    .ToList();
        }

        public Emprestimo GetById(int entityId)
        {
            return _context.Set<Emprestimo>()
                .Include(a => a.Usuario)
                .Include(l => l.Livro)
                    .SingleOrDefault(i => i.Id == entityId);
        }

        public void Delete(int entityId)
        {
            _context.Set<Emprestimo>().Remove(GetById(entityId));
            _context.SaveChanges();
        }

        public void Update(Emprestimo entity)
        {
            _context.Set<Emprestimo>().Update(entity);
            _context.SaveChanges();
        }
    }
}