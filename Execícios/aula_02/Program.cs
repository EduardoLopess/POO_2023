using aula_02;

Console.WriteLine("Hello, World!");

//Instanciar o objeto
Garrafa garrafa = new Garrafa(2031, "azul", 233, 999);

Console.WriteLine("Digite algo");
var retorno = Console.ReadLine();
Console.WriteLine("Saida.. " + retorno);


Console.WriteLine("Primeira nota: ");
var nota1 = Console.ReadLine();

Console.WriteLine("Segunda nota: ");
var nota2 = Console.ReadLine();

Console.WriteLine("Terceira nota: ");
var nota3 = Console.ReadLine();

var  media = (nota1 + nota2 + nota3);