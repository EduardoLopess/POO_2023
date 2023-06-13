using apiAS.Domain.Entities;
using apiAS.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace apiAS.Data.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DbContext _context;
        public SaleRepository()
        {
            _context = new DataContext();
        }
        public void Create(Sale entity)
        {
            var existingProducts = _context.Set<Product>().AsEnumerable()
                .Where(p => entity.Products.Any(ep => ep.IdProduct == p.IdProduct)).ToList();
            // Adicionar os produtos existentes a venda
            foreach (var existingProduct in existingProducts)
            {
                entity.Products.RemoveAll(p => p.IdProduct == existingProduct.IdProduct);
                entity.Products.Add(existingProduct);
            }
            _context.Set<Client>().Attach(entity.Client);
            _context.Set<Sale>().Add(entity);

            // Calcular o preco total da venda
            decimal totalPrice = entity.Products.Sum(p => p.Price);
            entity.TotalPrice = totalPrice;
            _context.SaveChanges();
        }

        public IList<Sale> GetAll()
        {
            return _context.Set<Sale>()
                .Include(c => c.Client)
                .Include(p => p.Products)
                    .ToList();
        }

        public Sale GetById(int entityId)
        {
            return _context.Set<Sale>()
                .Include(c => c.Client)
                .Include(p => p.Products)
                    .SingleOrDefault(i => i.IdSale == entityId);
        }

        public void Update(Sale entity, Product newProduct = null)
        {
            //Adicionar um novo produto a venda se necessario
            if (newProduct != null)
            {
                _context.Set<Product>().Add(newProduct);
                entity.Products.Add(newProduct);
            }

            _context.Set<Client>().Attach(entity.Client);
            _context.Entry(entity.Client).State = EntityState.Modified;
            decimal totalPrice = entity.Products.Sum(p => p.Price);
            entity.TotalPrice = totalPrice;

            _context.Set<Sale>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            _context.Set<Sale>().Remove(GetById(entityId));
            _context.SaveChanges();
        }

    }
}