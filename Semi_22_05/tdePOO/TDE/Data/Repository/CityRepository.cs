using Microsoft.EntityFrameworkCore;
using TDE.Domain.Entities;
using TDE.Domain.Interfaces;

namespace TDE.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DbContext context;

        public CityRepository(DbContext dbContext)
        {
            context = dbContext;
        }
        
        public void Create(City entity)
        {
            foreach (var person in entity.People)
            {
                person.City= entity;
            }

            context.Set<City>().Add(entity);
            context.SaveChanges();
        }

        public IList<City> GetAll()
        {
            return context.Set<City>().Include(p => p.People).ToList();
        }

        public City GetById(int entityId)
        {
            return context.Set<City>().Include(p => p.People)
                .SingleOrDefault(i => i.Id == entityId);
        }

        public void Update(City entity)
        {
            entity.People.ForEach(person => person.City = entity);
            context.Set<Person>().UpdateRange(entity.People);
            
            context.Set<City>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            context.Set<City>().Remove(GetById(entityId));
            context.SaveChanges();
        }

    
    }
}