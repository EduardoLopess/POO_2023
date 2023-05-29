namespace ap1.Models.Domains
{
    public class SaleItems
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int UnitPrice { get; set; }
        public decimal Total { get {return Amount * UnitPrice; } }
       
       //Associação entre Produto e venda
        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}