using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDE02.Models.Interfaces
{
    public interface IBaseRespositor<Entity> where Entity : class
    {
        Entity getById (int id);
        List<Entity> Getall();
        void Create(Entity entity);
        void Update (Entity entity);
        void Delete (int id);
    }
}