using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;

namespace Back_end.Models.Domain.DTOs
{
    public class PontoDoacaoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public MaterialDoacao MaterialDoacao { get; set; }
        public EnderecoDTO EnderecoDTO { get; set; }
        public int InstitutoId { get; set; } // user se for necessario incluir dps o instituto 
    }
}