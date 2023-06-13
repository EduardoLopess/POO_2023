using apiAS.Domain.Entities;
using apiAS.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace apiAS.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;
        public ProductRepository()
        {
            _context = new DataContext();
        }

        public void Create(Product entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IList<Product> GetAll()
        {
            return _context.Set<Product>()
            .AsNoTracking()
            .ToList();
        }

        public Product GetById(int entityId)
        {
            return _context.Set<Product>()
                .SingleOrDefault(p => p.IdProduct == entityId);
        }

        public void Update(Product entity)
        {
            _context.Set<Product>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            _context.Set<Product>().Remove(GetById(entityId));
            _context.SaveChanges();
        }
    }
}