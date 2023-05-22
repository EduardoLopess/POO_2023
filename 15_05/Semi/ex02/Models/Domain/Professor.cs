using ex02.Models.Interfaces;

namespace ex02.Models.Domain
{
    public class Professor : IPessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public void Falar()
        {
            Console.WriteLine($"Professor {Nome} falando");
        }
    }
}