using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.Entities
{
    public class Voluntariado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IList<VoluntariadoBeneficio> Beneficios { get; set; }
        public IList<VoluntariadoResponsabilidade> Responsabilidade { get; set; }

        public Instituto Instituto { get; set; } // um pra muitos
    }
}

