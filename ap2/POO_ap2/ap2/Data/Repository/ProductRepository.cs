using ap2.Domain.Entities;
using ap2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ap2.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext context;
        public ProductRepository(DbContext dbContext)
        {
            context = dbContext;
        }
        public void Create(Product entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public IList<Product> GetAll()
        {
            return context.Set<Product>()
            .AsNoTracking()
            .ToList();
            
        }

        public Product GetById(int entityId)
        {
            return context.Set<Product>()
                .SingleOrDefault(p => p.ProductId == entityId);
        }

        public void Update(Product entity)
        {
            context.Set<Product>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            context.Set<Product>().Remove(GetById(entityId));
            context.SaveChanges();
        }
    }
}