using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Enums;

namespace Back_end.Models.Domain.Entities
{
    public class Instituto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }

        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public IList<Voluntariado> Voluntariados { get; set; }
        public IList<MaterialDoacao> MaterialDoacaos { get; set; }
        public TipoInstituto TipoInstituto { get; set; }
    }
}