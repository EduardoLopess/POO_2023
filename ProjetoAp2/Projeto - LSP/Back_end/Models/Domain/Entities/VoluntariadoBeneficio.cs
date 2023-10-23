using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.Entities
{
    public class VoluntariadoBeneficio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        
        public int VoluntariadoId { get; set; }
        public Voluntariado Voluntariado { get; set; }
    }
}