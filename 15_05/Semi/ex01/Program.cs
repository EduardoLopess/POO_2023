using ex1.Models.Domain;
using semiPresencial_15_05_2023.Models.Domain;
using semiPresencial_15_05_2023.Models.Interfaces;

IPagamento cartaoCredito = new Cartao();
IPagamento boleto = new Boleto();
Cliente cliente1 = new Cliente(cartaoCredito);
Cliente cliente2 = new Cliente(boleto);
double valorCompra1 = 210.99;
double valorCompra2 = 199.99;

cliente1.Comprar(valorCompra1);
cliente2.Comprar(valorCompra2);
Console.ReadLine();