using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models.Domain.ViewModels
{
    public class EnderecoViewModel
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int CEP { get; set; }
        public string Cidade { get; set; }
    }
}