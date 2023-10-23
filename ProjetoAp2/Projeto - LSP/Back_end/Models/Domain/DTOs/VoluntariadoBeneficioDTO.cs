using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.DTOs
{
    public class VoluntariadoBeneficioDTO
    {
         public int Id { get; set; }
        public string Titulo { get; set; }
        public VoluntariadoDTO VoluntariadoDTO { get; set; }
        public int VoluntariadoId { get; set; }
    }
}