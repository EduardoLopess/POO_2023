
namespace c____aula_03.Models.Domain
{
    public class Person
    {
        public Person(int id, string name, int age, City city)
        {
            Id = id;
            Name = name;
            Age = age;
            City = city;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age {get; set;}

        public City City { get; set; }
    }
}