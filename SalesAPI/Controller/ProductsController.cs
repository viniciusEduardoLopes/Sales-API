using Microsoft.AspNetCore.Mvc;
using SaleAPI.Application.DTO;
using SaleAPI.Application.Interfaces;

namespace SalesAPI.Controller
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // api/products
        [HttpGet]
        public async Task<IActionResult> GetProductssList()
        {
            var products = await _productsService.GetAllAsync();
            return Ok(products);
        }

        // api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productsService.GetByIdAsync(id);
            if (product == null)
                return NotFound(new { mensagem = "Producto não encontrado" });

            return Ok(product);
        }

        // api/products
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductsDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productsService.AddAsync(productDTO);
            return CreatedAtAction(nameof(AddProduct), new { id = productDTO.Id }, productDTO);
        }

        // api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductsDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productsService.UpdateAsync(productDto);
            return NoContent();
        }

        // api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _productsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
