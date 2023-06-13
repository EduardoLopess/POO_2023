namespace ap2.Domain.Entities
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            
            Name = name;
            Price = price;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}