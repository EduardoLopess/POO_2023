using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instituto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }

        public Endereco Endereco { get; set; }
        public IList<Volutariado> Voluntariados { get; set; } 
    }
}   


