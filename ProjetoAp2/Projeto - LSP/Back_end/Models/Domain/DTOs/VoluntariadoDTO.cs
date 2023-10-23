using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.DTOs
{
    public class VoluntariadoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IList<VoluntariadoBeneficioDTO> BeneficioDTOs { get; set; }
        public IList<VoluntariadoResponsabilidadeDTO> ResponsabilidadeDTOs { get; set; }

        public int InstitutoId { get; set; }
    }
}