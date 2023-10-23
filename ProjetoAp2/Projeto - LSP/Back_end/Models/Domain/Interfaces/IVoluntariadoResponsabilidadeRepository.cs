using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Data.Repository;
using Back_end.Models.Domain.Entities;

namespace Back_end.Models.Domain.Interfaces
{
    public interface IVoluntariadoResponsabilidadeRepository : IBaseRepository<VoluntariadoResponsabilidade>
    {
        Task CreateAsync(VoluntariadoResponsabilidade entity, Voluntariado voluntariado);
    }
}