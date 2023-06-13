using System.ComponentModel.DataAnnotations;

namespace apiAS.Domain.Entities
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}