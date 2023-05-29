using ap2.Controller;
using ap2.Data;
using ap2.Data.Repository;

class program
{
    static void Main(string[] args)
    {
        var dbContext = new DataContext();

        var clientRepository = new ClientRepository(dbContext);
        var productRepository = new ProductRepository(dbContext);
        var saleRepository = new SaleRepository(dbContext);

        var clientController = new ClientController(clientRepository);
        var productController = new ProductController(productRepository);
        var saleController = new SaleController(saleRepository, clientRepository, productRepository);

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("==== Menu ====");
            Console.WriteLine("1. Clientes");
            Console.WriteLine("2. Produtos");
            Console.WriteLine("3. Vendas");
            Console.WriteLine("0. Sair");

            Console.WriteLine("Selecione uma opção:");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("==== Menu Clientes ====");
                    Console.WriteLine("1. Adicionar Cliente");
                    Console.WriteLine("2. Listar Clientes");
                    Console.WriteLine("3. Atualizar Cliente");
                    Console.WriteLine("4. Excluir Cliente");
                    Console.WriteLine("0. Voltar ao Menu Principal");

                    string clientOpts = Console.ReadLine();
                    switch (clientOpts)
                    {
                        case "1":
                            clientController.AddClient();
                            break;
                        case "2":
                            clientController.ListClients();
                            break;
                        case "3":
                            clientController.Update();
                            break;
                        case "4":
                            clientController.Delete();
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("==== Menu Produtos ====");
                    Console.WriteLine("1. Adicionar Produto");
                    Console.WriteLine("2. Listar Produtos");
                    Console.WriteLine("3. Atualizar Produto");
                    Console.WriteLine("4. Excluir Produto");
                    Console.WriteLine("0. Voltar ao Menu Principal");

                    string productOps = Console.ReadLine();
                    switch (productOps)
                    {
                        case "1":
                            productController.AddProduct();
                            break;
                        case "2":
                            productController.ListProducts();
                            break;
                        case "3":
                            productController.Update();
                            break;
                        case "4":
                            productController.Delete();
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("==== Menu Vendas ====");
                    Console.WriteLine("1. Adicionar Venda");
                    Console.WriteLine("2. Listar Vendas");
                    Console.WriteLine("3. Atualizar Venda");
                    Console.WriteLine("4. Excluir Venda");
                    Console.WriteLine("0. Voltar ao Menu Principal");

                    string saleOpts = Console.ReadLine();
                    switch (saleOpts)
                    {
                        case "1":
                            saleController.AddSale();
                            break;
                        case "2":
                            saleController.ListSales();
                            break;
                        case "3":
                            saleController.Update();
                            break;
                        case "4":
                            saleController.Delete();
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }

                    break;
                case "0":
                    Console.WriteLine("Saindo...");
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }

}