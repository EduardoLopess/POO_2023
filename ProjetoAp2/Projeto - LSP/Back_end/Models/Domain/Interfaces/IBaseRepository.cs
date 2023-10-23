using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Task<Entity> GetByIdAsync (int entityId);
        Task<IList<Entity>> GetAllAsync(); 
        Task DeleteAsync(int entityId); 
        Task UpdateAsync(Entity entity); 
    }
}