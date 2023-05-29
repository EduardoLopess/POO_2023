using ap2.Domain.Entities;
using ap2.Domain.Interfaces;

namespace ap2.Controller
{
    public class ProductController
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void MenuProductor()
        {
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("===== Gerenciar Produtos =====");
                Console.WriteLine("1. Listar Produtos");
                Console.WriteLine("2. Adicionar Produto");
                Console.WriteLine("3. Atualizar Produto");
                Console.WriteLine("4. Excluir Produto");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.WriteLine("==============================");
                Console.Write("Digite a opção desejada: ");
                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                         AddProduct();
                        break;
                    case "2":
                        ListProducts();
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

        public void AddProduct()
        {
            Console.WriteLine("===== Adicionar Produto =====");
            Console.Write("Digite o nome do produto: ");
            string name = Console.ReadLine();
            Console.Write("Digite o preço do produto: ");
            decimal price = decimal.Parse(Console.ReadLine());

            var product = new Product(name, price);
            productRepository.Create(product);

            Console.WriteLine("Produto adicionado com sucesso!");
        }

        public void ListProducts()
        {
            Console.WriteLine("===== Lista de Produtos =====");
            var products = productRepository.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine
                (
                    $"Produto ID: {product.ProductId}, Nome: {product.Name}, Valor: {product.Price}"   
                );

            }
        }


        public void Update()
        {
            Console.WriteLine("===== Atualizar Produto =====");
            ListProducts();
            Console.WriteLine("==============================");
            Console.Write("Digite o ID do produto a ser atualizado: ");
            int productId = int.Parse(Console.ReadLine());

            var product = productRepository.GetById(productId);
            if (product == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.Write("Digite o novo nome do produto: ");
            string newName = Console.ReadLine();
            Console.Write("Digite o novo preço do produto: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            product.Name = newName;
            product.Price = newPrice;

            productRepository.Update(product);

            Console.WriteLine("Produto atualizado com sucesso!");
        }

        public void Delete()
        {
            Console.WriteLine("===== Excluir Produto =====");
            ListProducts();
            Console.WriteLine("==============================");
            Console.Write("Digite o ID do produto a ser excluído: ");
            int productId = int.Parse(Console.ReadLine());

            var product = productRepository.GetById(productId);
            if (product == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            productRepository.Delete(productId);

            Console.WriteLine("Produto excluído com sucesso!");
        }
    }
}