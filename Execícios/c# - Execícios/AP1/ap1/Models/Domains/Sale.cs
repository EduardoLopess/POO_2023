namespace ap1.Models.Domains
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime DateSale { get; set; }
        public string Payment { get; set; }
        public double Total 
        { get 
            {   
             return (double)SaleItems.Sum(Product => Product.Total);
            } 
        }
        public List<SaleItems> SaleItems { get; set; }

    }
}