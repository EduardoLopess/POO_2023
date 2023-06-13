using apiAS.Data.Repository;
using apiAS.Domain.Entities;
using apiAS.Domain.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace apiAS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository repository;

        public ClientController()
        {
            this.repository = new ClientRepository();
        }


        [HttpGet]
        public IEnumerable<Client>Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Client client)
        {
            repository.Create(client);
            return Ok( new
            {
                statusCode = 200,
                message = "Cliente cadastrado com sucesso"
            });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok(new{
                message = "Deletado com sucesso",
                erroCod = 202      
            });
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Client client)
        {
            repository.Update(client);
            return Ok(new {
                message = "Cliente Atualizado! ",
                erroCode = 202
            });
        }
        
    }
}