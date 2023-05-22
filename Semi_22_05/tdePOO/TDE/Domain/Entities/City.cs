namespace TDE.Domain.Entities
{
    public class City
    {
        public City()
        {
            People = new List<Person>();
        }

        public City(int id, string name, List<Person> people)
        {
            Id = id;
            Name = name;
            People = people;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        //Referencia
        //Uma Cidade tem muitas pessoas 1 pra N
        public List<Person> People { get; set; }
        
    }
}