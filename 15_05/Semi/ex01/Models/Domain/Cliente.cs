using semiPresencial_15_05_2023.Models.Interfaces;

namespace semiPresencial_15_05_2023.Models.Domain
{
    public class Cliente
    {
        private IPagamento metodoPagamento;

        public Cliente(IPagamento metodoPagamento)
        {
            this.metodoPagamento = metodoPagamento;
        }

        public void Comprar(double valor)
        {
            metodoPagamento.Pagar(valor);
        }
    }
}