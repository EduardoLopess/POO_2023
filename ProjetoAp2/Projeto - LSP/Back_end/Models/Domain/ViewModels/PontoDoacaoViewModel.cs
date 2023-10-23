using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;

namespace Back_end.Models.Domain.ViewModels
{
    public class PontoDoacaoViewModel
    {
        public string Descricao { get; set; }

        public MaterialDoacao MaterialDoacao { get; set; }
    }
}