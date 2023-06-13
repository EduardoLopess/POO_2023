namespace apiAS.Domain.Entities
{
    public class Sale
    {
        public int IdSale { get; set; }
        public decimal TotalPrice { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}