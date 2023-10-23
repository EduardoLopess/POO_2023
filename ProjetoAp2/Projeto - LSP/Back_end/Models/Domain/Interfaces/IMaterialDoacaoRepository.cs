using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;

namespace Back_end.Models.Domain.Interfaces
{
    public interface IMaterialDoacaoRepository : IBaseRepository<MaterialDoacao>
    {
        Task CreateAsync(MaterialDoacao entity, Instituto instituto, PontoDoacao pontoDoacao);
    }
}