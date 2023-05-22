using TDE.Data;
using TDE.Data.Repository;
using TDE.Domain.Entities;
using TDE.Domain.Interfaces;

using (var context = new DataContext())
{
    var personRepository = new PersonRepository(context);
    var cityRepository = new CityRepository(context);

    Console.WriteLine("Pessoa/cidade");

    var city = new City
    {
        Name = "BR",
        People = new List<Person>
        {
            new Person { Name = "Teste pessoa 1", PhoneNumber = "1234567890" },
            new Person { Name = "Teste pessoa 2", PhoneNumber = "9876543210" }
        }
    };

    // Adicionar a cidade ao banco de dados
    cityRepository.Create(city);
    context.SaveChanges();

    var person1 = new Person
    {
        Name = "Teste pessoa 3",
        PhoneNumber = "1234567890",
        CityId = city.Id
    };

    var person2 = new Person
    {
        Name = "Teste pessoa 4",
        PhoneNumber = "9876543210",
        CityId = city.Id
    };

    // Adicionar as pessoas ao banco de dados
    personRepository.Create(person1, city.Id);
    personRepository.Create(person2, city.Id);
    context.SaveChanges();

    // Obter todas as pessoas
    var people = personRepository.GetAll();

    // Exibir as informações das pessoas
    Console.WriteLine("Lista de Pessoas:");
    foreach (var person in people)
    {
        Console.WriteLine($"ID: {person.Id}, Nome: {person.Name}, Telefone: {person.PhoneNumber}");
    }

    // Obter todas as cidades com as pessoas associadas
    var cities = cityRepository.GetAll();

    // Exibir as informações das cidades e pessoas
    Console.WriteLine("Lista de Cidades e Pessoas:");
    foreach (var City in cities)
    {
        Console.WriteLine($"Cidade: {city.Name}");

        foreach (var person in city.People)
        {
            Console.WriteLine($"- Pessoa: {person.Name}, Telefone: {person.PhoneNumber}");
        }

        Console.WriteLine();
    }
   
    var personToUpdate = personRepository.GetById(person1.Id);
    personToUpdate.Name = "Teste pessoa 3 atualizada";
    personRepository.Update(personToUpdate);

    // Excluir uma pessoa
    personRepository.Delete(person2.Id);
    context.SaveChanges();

}

