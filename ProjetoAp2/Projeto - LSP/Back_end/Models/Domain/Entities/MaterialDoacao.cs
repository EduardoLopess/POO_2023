using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Enums;

namespace Back_end.Models.Domain.Entities
{
    public class MaterialDoacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Instituto Instituto { get; set; }
        public TipoMaterial TipoMaterial { get; set; }
        public PontoDoacao PontoDoacao { get; set; }
        public int PontoDoacaoId { get; set; }
        public PrioridadeDoacao PrioridadeDoacao { get; set; }
    }
}