using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;

namespace Back_end.Models.Domain.Interfaces
{
    public interface IInstitutoRepository : IBaseRepository<Instituto>
    {
         Task CreateAsync(Instituto entity, Endereco endereco);
         //Task CreateAsync(Instituto entity, IList<Voluntariado> voluntariados);
         //Task CreateAsync(Instituto entity, IList<MaterialDoacao> materialDoacaos);
    }
}