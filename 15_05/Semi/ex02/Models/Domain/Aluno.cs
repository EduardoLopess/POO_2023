using ex02.Models.Interfaces;

namespace ex02.Models.Domain
{
    public class Aluno : IPessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public void Falar()
        {
            Console.WriteLine($"Aluno {Nome} fala");
        }
    }    
}