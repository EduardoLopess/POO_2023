using System.ComponentModel.DataAnnotations;

namespace apiAS.Domain.Entities
{
    public class Client
    {
      
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}