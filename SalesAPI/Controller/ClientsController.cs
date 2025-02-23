using Microsoft.AspNetCore.Mvc;
using SaleAPI.Application.DTO;
using SaleAPI.Application.Interfaces;
using SaleAPI.Application.Service;

namespace SalesAPI.Controller
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        // api/clientes
        [HttpGet]
        public async Task<IActionResult> GetClientsList()
        {
            var clients = await _clientsService.GetAllAsync();
            return Ok(clients);
        }

        // api/clientes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _clientsService.GetByIdAsync(id);
            if (client == null)
                return NotFound(new { mensagem = "Cliente não encontrado" });

            return Ok(client);
        }

        // api/clientes
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] ClientsDTO clientDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clientsService.AddAsync(clientDTO);
            return CreatedAtAction(nameof(AddClient), new { id = clientDTO.Id }, clientDTO);
        }

        // api/clientes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientsDTO clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clientsService.UpdateAsync(clientDto);
            return NoContent();
        }

        // api/clientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveClient(int id)
        {
            await _clientsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
