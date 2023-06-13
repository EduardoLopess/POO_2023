using apiAS.Data.Repository;
using apiAS.Domain.Entities;
using apiAS.Domain.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace apiAS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController()
        {
            this.repository = new ProductRepository();
        }


        [HttpGet]
        public IEnumerable<Product>Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            repository.Create(product);
            return Ok( new
            {
                statusCode = 200,
                message = "Produto cadastrado.", 
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
        public ActionResult Put([FromBody] Product product)
        {
            repository.Update(product);
            return Ok(new {
                message = "Produto Atualizado! ",
                erroCode = 202
            });
        }
    }
}