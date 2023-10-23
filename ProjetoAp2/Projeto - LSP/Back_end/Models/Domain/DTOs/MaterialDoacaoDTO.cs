using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Enums;

namespace Back_end.Models.Domain.DTOs
{
    public class MaterialDoacaoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public InstitutoDTO InstitutoDTO { get; set; }
        public TipoMaterial TipoMaterial { get; set; }
        public PrioridadeDoacao PrioridadeDoacao { get; set; }
    }
}