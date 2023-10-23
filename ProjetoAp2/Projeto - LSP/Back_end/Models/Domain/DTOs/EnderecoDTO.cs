using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int CEP { get; set; }
        public string Cidade { get; set; }

        public InstitutoDTO InstitutoDTO { get; set; }
        public int InstitutoId { get; set; }
        public PontoDoacaoDTO PontoDoacaoDTO { get; set; }
        public int PontoDoacaoId { get; set; }
    }
}