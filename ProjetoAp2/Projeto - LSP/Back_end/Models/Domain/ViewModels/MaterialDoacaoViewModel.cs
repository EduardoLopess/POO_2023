using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Enums;

namespace Back_end.Models.Domain.ViewModels
{
    public class MaterialDoacaoViewModel
    {
        public string Descricao { get; set; }

        //public Instituto Instituto { get; set; }
        public TipoMaterial TipoMaterial { get; set; }
        //public PontoDoacao PontoDoacao { get; set; }
        public PrioridadeDoacao PrioridadeDoacao { get; set; }
    }
}