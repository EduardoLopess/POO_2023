using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.Entities
{
    public class PontoDoacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public MaterialDoacao MaterialDoacao { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public Instituto Instituto { get; set; }
        public int InstitutoId { get; set; }
    }
}