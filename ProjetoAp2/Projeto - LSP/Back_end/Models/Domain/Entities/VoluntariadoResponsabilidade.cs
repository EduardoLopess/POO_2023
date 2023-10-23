using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.Entities
{
    public class VoluntariadoResponsabilidade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Voluntariado Voluntariado { get; set; }
        public int VoluntariadoId { get; set; }
    }
}