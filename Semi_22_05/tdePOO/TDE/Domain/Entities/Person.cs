namespace TDE.Domain.Entities
{
    public class Person
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        //Referencia
        //Pessoa pertencene a uma cidade 1 pra 1
        public virtual City City { get; set; }
        public int CityId { get; set; }
    
    }
}