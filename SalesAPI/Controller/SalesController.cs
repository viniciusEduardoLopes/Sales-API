using Microsoft.AspNetCore.Mvc;
using SaleAPI.Application.DTO;
using SaleAPI.Application.Interfaces;
using SaleAPI.Domain.Entities;

namespace SalesAPI.Controller
{
    [ApiController]
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesList()
        {
            var sales = await _salesService.GetAllAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesById(int id)
        {
            var sale = await _salesService.GetByIdAsync(id);
            if (sale == null)
                return NotFound(new { mensagem = "Venda não encontrada" });

            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> AddSale([FromBody] SalesDTO saleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _salesService.AddAsync(saleDto);
            return CreatedAtAction(nameof(AddSale), new { id = saleDto.Id }, saleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, [FromBody] SalesDTO saleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _salesService.UpdateAsync(saleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSale(int id)
        {
            await _salesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
