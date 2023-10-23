using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Enums;

namespace Back_end.Models.Domain.DTOs
{
    public class InstitutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }

        public EnderecoDTO EnderecoDTO { get; set; }
        public int EnderecoId { get; set; }
        public IList<VoluntariadoDTO> VoluntariadoDTOs { get; set; }
        public IList<MaterialDoacaoDTO> MaterialDoacaoDTOs { get; set; }

        public TipoInstituto TipoInstituto { get; set; }
    }
}