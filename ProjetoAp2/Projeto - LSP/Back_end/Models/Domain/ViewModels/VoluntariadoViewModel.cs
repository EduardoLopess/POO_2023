using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.ViewModels
{
    public class VoluntariadoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IList<VoluntariadoBeneficioViewModel> BeneficioViewModels { get; set; }
        public IList<VoluntariadoResponsabilidadeViewModel> ResponsabilidadeViewModels { get; set; }

        public InstitutoViewModel InstitutoViewModel { get; set; }
    }
}