namespace ap1.Models.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Entity GetById (int id);
        List<Entity> GetAll();
        void Create(Entity entity);
        void Update (Entity entity);
        void Delete (Entity entity);
    }
}