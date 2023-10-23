using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;

namespace Back_end.Models.Domain.Interfaces
{
    public interface IVoluntariadoRepository : IBaseRepository<Voluntariado>
    {
        Task CreateAsync(Voluntariado entity, IList<VoluntariadoResponsabilidade> responsabilidades, IList<VoluntariadoBeneficio> beneficios);

    }
}