using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c____aula_03.Models.Domain
{
    public class City
    {
        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}