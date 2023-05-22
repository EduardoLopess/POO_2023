using System;
using semiPresencial_15_05_2023.Models.Interfaces;

namespace semiPresencial_15_05_2023.Models.Domain
{
    public class Cartao : IPagamento
    {
        public void Pagar(double valor)
        {
            Console.WriteLine($"Pagamento realizado com cartão. Valor: R$ {valor}");
        }
    }
}