using semiPresencial_15_05_2023.Models.Interfaces;

namespace ex1.Models.Domain
{
    public class Boleto : IPagamento
    {
        public void Pagar(double valor)
        {
            Console.WriteLine($"Pagamento realizado com boleto. Valor: R$ {valor}");
        }
    }
}