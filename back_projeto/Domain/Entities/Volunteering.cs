using System.Net.NetworkInformation;

namespace Domain.Entities
{
    public class Volunteering
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Benefit { get; set; }
        public string Responsibilitys { get; set;}
        public IList<Benefit> Benefits { get; set; }
        public IList<Responsibility> Responsibility { get; set; }

        public Institute Institute { get; set; }

    }
 }