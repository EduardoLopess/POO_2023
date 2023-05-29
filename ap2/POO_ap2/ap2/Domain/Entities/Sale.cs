namespace ap2.Domain.Entities
{
    public class Sale
    {
       
        public int SaleId { get; set; }
        public decimal TotalPrice { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}