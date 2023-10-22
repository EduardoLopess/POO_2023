using Domain.Enums;
using Domain.Services;

namespace Domain.Entities
{
    public class User : LoginInfos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        

        public IList<Address> Addresses { get; set; }
        public Login Login { get; set; }
    
    }
}
