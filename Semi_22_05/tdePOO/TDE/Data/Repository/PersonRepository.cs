using Microsoft.EntityFrameworkCore;
using TDE.Domain.Entities;
using TDE.Domain.Interfaces;

namespace TDE.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbContext context;

        public PersonRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        public void Create(Person person, int cityId)
        {
           var city = context.Set<City>().Find(cityId);

           if(city == null)
           {
                throw new ArgumentException("Cidade não foi encontrado");
           }

           person.CityId = cityId; 
           person.City = city;
           context.Set<Person>().Add(person);
           context.SaveChanges();
        }

        public IList<Person> GetAll()
        {
            return context.Set<Person>().Include(p => p.City).ToList();
        }

        public Person GetById(int entityId)
        {
            return context.Set<Person>().Include(p => p.City)
                .SingleOrDefault(i => i.Id == entityId);
        }

        public void Delete(int entityId)
        {
            context.Set<Person>().Remove(GetById(entityId));
            context.SaveChanges();
        }

        public void Update(Person entity)
        {
            var city = context.Set<City>().Find(entity.CityId);
            entity.City = city;
            context.Set<Person>().Update(entity);
            context.SaveChanges();
        }

        

    }

    
}