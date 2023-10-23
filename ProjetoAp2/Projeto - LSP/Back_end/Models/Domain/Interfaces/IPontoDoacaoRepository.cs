using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;

namespace Back_end.Models.Domain.Interfaces
{
    public interface IPontoDoacaoRepository : IBaseRepository<PontoDoacao>
    {
         Task CreateAsync(PontoDoacao entity, Endereco endereco, MaterialDoacao materiaisDoacao);
    }
}