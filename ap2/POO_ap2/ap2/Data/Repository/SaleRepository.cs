using ap2.Domain.Entities;
using ap2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ap2.Data.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DbContext context;
        public SaleRepository(DbContext dbContext)
        {
            context = dbContext;
        }
        
        public void Create(Sale entity)
        {
            //Verifica se os produtos ja existem no banco de dados(Evitar erro de ID duplicado)
            var existingProducts = context.Set<Product>().AsEnumerable()
                .Where(p => entity.Products.Any(ep => ep.ProductId == p.ProductId)).ToList();

            // Adicionar os produtos existentes a venda
            foreach (var existingProduct in existingProducts)
            {
                entity.Products.RemoveAll(p => p.ProductId == existingProduct.ProductId);
                entity.Products.Add(existingProduct);
            }
            context.Set<Client>().Attach(entity.Client);
            context.Set<Sale>().Add(entity);

            // Calcular o preco total da venda
            decimal totalPrice = entity.Products.Sum(p => p.Price);
            entity.TotalPrice = totalPrice;
            context.SaveChanges();
        }

        public IList<Sale> GetAll()
        {
            return context.Set<Sale>()
                .Include(c => c.Client)
                .Include(p => p.Products)
                    .ToList();
        }

        public Sale GetById(int entityId)
        {
            return context.Set<Sale>()
                .Include(c => c.Client)
                .Include(p => p.Products)
                    .SingleOrDefault(i => i.SaleId == entityId);
        }

        public void Update(Sale entity, Product newProduct)
        {
            //Adicionar um novo produto a venda se necessario
            if (newProduct != null)
            {
                context.Set<Product>().Add(newProduct);
                entity.Products.Add(newProduct);
            }

            context.Set<Client>().Attach(entity.Client);
            context.Entry(entity.Client).State = EntityState.Modified;
            decimal totalPrice = entity.Products.Sum(p => p.Price);
            entity.TotalPrice = totalPrice;

            context.Set<Sale>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            context.Set<Sale>().Remove(GetById(entityId));
            context.SaveChanges();
        }

    }
}