using Microsoft.AspNetCore.Mvc;
using apiAS.Domain.Entities;
using apiAS.Domain.Intefaces;
using apiAS.Data.Repository;

namespace ap2.Controllers
{
    [ApiController]
    [Route("api/sale")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository saleRepository;
        private readonly IClientRepository clientRepository;
        private readonly IProductRepository productRepository;

        public SaleController()
        {
            this.saleRepository = new SaleRepository(); 
            this.clientRepository = new ClientRepository(); 
            this.productRepository = new ProductRepository(); 
        }

        [HttpGet]
        public IActionResult GetSales()
        {
            var sales = saleRepository.GetAll();

            return Ok(sales);
        }

        [HttpGet("{id}")]
        public IActionResult GetSale(int id)
        {
            var sale = saleRepository.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        [HttpPost]
        public IActionResult CreateSale(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            saleRepository.Create(sale);

            return CreatedAtAction(nameof(GetSale), new { id = sale.IdSale }, sale);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, Sale updatedSale)
        {
            if (id != updatedSale.IdSale)
            {
                return BadRequest();
            }

            var existingSale = saleRepository.GetById(id);
            if (existingSale == null)
            {
                return NotFound();
            }

            existingSale.Products = updatedSale.Products;
            existingSale.TotalPrice = updatedSale.Products.Sum(p => p.Price);

            saleRepository.Update(existingSale);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var sale = saleRepository.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }

            saleRepository.Delete(id);

            return NoContent();
        }
    }
}
