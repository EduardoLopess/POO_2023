using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Volutariado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IList<string> Beneficios { get; set; }
        public IList<string> Responsabilidade { get; set; }
       
        public Instituto Instituto { get; set; }
    }
}