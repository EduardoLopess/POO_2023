namespace ap2.Domain.Entities
{
    public class Client
    {
        public Client(string name, string address)
        {

            Name = name;
            Address = address;
        }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}