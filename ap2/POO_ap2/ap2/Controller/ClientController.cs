using ap2.Domain.Entities;
using ap2.Domain.Interfaces;

namespace ap2.Controller
{
    public class ClientController
    {
        private readonly IClientRepository clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public void ListClients()
        {
            Console.WriteLine("===== Lista de Clientes =====");
            var clients = clientRepository.GetAll();
            foreach (var client in clients)
            {
                Console.WriteLine($"Cliente ID: {client.ClientId}, Nome: {client.Name}, Endereço: {client.Address}");
            }
            Console.WriteLine("=============================");
        }

        public void AddClient()
        {
            Console.WriteLine("===== Adicionar Cliente =====");
            Console.Write("Digite o nome do cliente: ");
            string name = Console.ReadLine();
            Console.Write("Digite o endereço do cliente: ");
            string address = Console.ReadLine();

            var client = new Client(name, address);
            clientRepository.Create(client);

            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        public void Update()
        {
            Console.WriteLine("===== Atualizar Cliente =====");
            ListClients();
            Console.WriteLine("=============================");
            Console.Write("Digite o ID do cliente a ser atualizado: ");
            int clientId = int.Parse(Console.ReadLine());

            var client = clientRepository.GetById(clientId);
            if (client == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            Console.Write("Digite o novo nome do cliente: ");
            string name = Console.ReadLine();
            Console.Write("Digite o novo endereço do cliente: ");
            string address = Console.ReadLine();

            client.Name = name;
            client.Address = address;
            clientRepository.Update(client);

            Console.WriteLine("Cliente atualizado com sucesso!");
        }
        

        public void Delete()
        {
            Console.WriteLine("===== Excluir Cliente =====");
            ListClients();
            Console.WriteLine("=============================");
            Console.Write("Digite o ID do cliente a ser excluído: ");
            int clientId = int.Parse(Console.ReadLine());

            var client = clientRepository.GetById(clientId);
            if (client == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            clientRepository.Delete(clientId);

            Console.WriteLine("Cliente excluído com sucesso!");
        }
    }
}