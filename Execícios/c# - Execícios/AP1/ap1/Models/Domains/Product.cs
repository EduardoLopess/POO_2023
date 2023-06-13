using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ap1.Models.Domains
{
    public class Product
    {
        public int Id { get; set; }
        public int Barcod { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
    }
}