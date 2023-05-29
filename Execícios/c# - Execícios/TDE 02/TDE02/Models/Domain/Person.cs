namespace TDE02.Models.Domain
{
    public class Person
    {
        public Person(int id, string name, int age, string phone, City city)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            City = city;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public City City { get; set; }
        public static List<Person> People {get ; set; } = new List<Person>(); 
    }
}