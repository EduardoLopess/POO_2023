using ap2.Domain.Entities;
using ap2.Domain.Interfaces;

namespace ap2.Controller
{
    public class SaleController
    {
        private readonly ISaleRepository saleRepository;
        private readonly IClientRepository clientRepository;
        private readonly IProductRepository productRepository;
       
        public SaleController(ISaleRepository saleRepository, IClientRepository clientRepository, IProductRepository productRepository)
        {
            this.saleRepository = saleRepository;
            this.clientRepository = clientRepository;
            this.productRepository = productRepository;
        }

        public void MenuSale()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("===== Gerenciar Vendas =====");
                Console.WriteLine("1. Listar Vendas");
                Console.WriteLine("2. Registrar Venda");
                Console.WriteLine("3. Atualizar Venda");
                Console.WriteLine("4. Excluir Venda");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.WriteLine("============================");
                Console.Write("Digite a opção desejada: ");
                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        ListSales();
                        break;
                    case "2":
                        AddSale();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public void AddSale()
        {
           
            Console.WriteLine("===== Registrar Venda =====");
            // Listar os clientes disponíveis
            Console.WriteLine("Clientes disponíveis:");
            var clients = clientRepository.GetAll();
            foreach (var cli in clients)
            {
                Console.WriteLine($"ID: {cli.ClientId} | Nome: {cli.Name}");
            }

            //Ligar cliente a venda
            Console.Write("Digite o ID do cliente: ");
            int clientId = int.Parse(Console.ReadLine());

            var selectedClient = clientRepository.GetById(clientId);
            if (selectedClient == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            // Listar os produtos disponíveis
            Console.WriteLine("Produtos disponíveis:");
            var products = productRepository.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId} | Nome: {product.Name} | Valor: R${product.Price}");
            }

            List<Product> selectedProducts = new List<Product>();

            bool addProducts = true;
            while (addProducts)
            {
                Console.Write("Digite o ID do produto: ");
                int productId = int.Parse(Console.ReadLine());

                var product = productRepository.GetById(productId);
                if (product == null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    continue;
                }

                Console.WriteLine($"ID: {product.ProductId} | Nome: {product.Name} | Valor: R${product.Price}");
                selectedProducts.Add(product);

                Console.Write("Deseja adicionar mais produtos? (S/N): ");
                string opts = Console.ReadLine();
                addProducts = (opts.ToLower() == "s");
            }

            var sale = new Sale
            {
                ClientId = clientId,
                Client = selectedClient,
                Products = selectedProducts
            };

            saleRepository.Create(sale);
            Console.WriteLine("Venda salva com sucesso!");
        }   


        public void ListSales()
        {
            Console.WriteLine("===== Lista de Vendas =====");
            var sales = saleRepository.GetAll();
            foreach (var sale in sales)
            {
                Console.WriteLine($"Venda ID: {sale.SaleId}| Cliente: {sale.Client.Name}| Total: {sale.TotalPrice}");
                foreach (var product in sale.Products)
                {
                    Console.WriteLine($"---->  Produto: {product.Name} | Valor: R${product.Price}");
                }
                Console.WriteLine("===========================");
            }
        }

        public void Update()
        {
            Console.WriteLine("===== Atualizar Venda =====");
            ListSales();
            Console.WriteLine("==============================");
            Console.Write("Digite o ID da venda a ser atualizada: ");
            int saleId = int.Parse(Console.ReadLine());

            var sale = saleRepository.GetById(saleId);
            if (sale == null)
            {
                Console.WriteLine("Venda não encontrada.");
                return;
            }

            Console.WriteLine("Produtos na venda:");
            foreach (var product in sale.Products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Nome: {product.Name}");
            }

            Console.WriteLine("Produtos disponíveis:");
            var products = productRepository.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId} | Nome: {product.Name} | Valor: R${product.Price}");
            }

            Console.WriteLine("Opções:");
            Console.WriteLine("1. Adicionar um novo produto à venda");
            Console.WriteLine("2. Remover um produto da venda");
            Console.Write("Digite o número da opção desejada: ");
            int opts = int.Parse(Console.ReadLine());

            switch (opts)
            {
                case 1:
                    Console.Write("Digite o ID do novo produto a ser adicionado à venda: ");
                    int newProductId = int.Parse(Console.ReadLine());

                    var newProduct = products.FirstOrDefault(p => p.ProductId == newProductId);
                    if (newProduct == null)
                    {
                        Console.WriteLine("Produto não encontrado.");
                        return;
                    }

                    sale.Products.Add(newProduct);
                    break;

                case 2:
                    Console.Write("Digite o ID do produto a ser removido da venda: ");
                    int productId = int.Parse(Console.ReadLine());

                    var productToRemove = sale.Products.FirstOrDefault(p => p.ProductId == productId);
                    if (productToRemove == null)
                    {
                        Console.WriteLine("Produto não encontrado na venda.");
                        return;
                    }

                    sale.Products.Remove(productToRemove);
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }

            // Atualize o preco total da venda
            decimal totalPrice = sale.Products.Sum(p => p.Price);
            sale.TotalPrice = totalPrice;

            saleRepository.Update(sale);

            Console.WriteLine("Venda atualizada com sucesso!");
        }
        public void Delete()
        {
            Console.WriteLine("===== Excluir Venda =====");
            ListSales();
            Console.WriteLine("==============================");
            Console.Write("Digite o ID da venda a ser excluída: ");
            int saleId = int.Parse(Console.ReadLine());

            var sale = saleRepository.GetById(saleId);
            if (sale == null)
            {
                Console.WriteLine("Venda não encontrada.");
                return;
            }

            saleRepository.Delete(saleId);

            Console.WriteLine("Venda excluída com sucesso!");
        }
    }
}
