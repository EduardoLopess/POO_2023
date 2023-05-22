using ex02.Models.Interfaces;

namespace ex02.Models.Domain
{
    public class Escola
    {
        public void ApresentarPessoa(IPessoa pessoa)
        {
            Console.WriteLine($"Apresentando: {pessoa.Nome}, {pessoa.Idade} anos");
            pessoa.Falar();
        }

    }
}