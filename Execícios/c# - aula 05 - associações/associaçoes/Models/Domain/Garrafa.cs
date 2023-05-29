using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace associaçoes.Models.Domain
{
    public class Garrafa
    {
        public Garrafa(string codBarras, string marca, int volume)
        {
            CodBarras = codBarras;
            Marca = marca;
            Volume = volume;
        }

        public string CodBarras { get; protected set; }
        public string Marca { get; set; }
        public int Volume { get; set; }
    }
}