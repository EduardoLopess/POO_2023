using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDE02.Models.Domain
{
    public class City
    {
        public City(int id, string name, string state, string contry, Person person)
        {
            Id = id;
            Name = name;
            State = state;
            Contry = contry;
            Person = person;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Contry { get; set; }
        public Person Person { get; set; }
        public static List<City> Cities { get; set; } = new List<City>();
    }

}