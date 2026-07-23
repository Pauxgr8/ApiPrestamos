using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repository;

        public ClienteController(ClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] Cliente cliente)
        {
            await _repository.CrearCliente(cliente);
            return CreatedAtAction(nameof(BuscarClientePorId), new { id = cliente.IdCliente }, cliente);
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> LeerClientes()
        {
            return await _repository.LeerClientes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> BuscarClientePorId(int id)
        {
            var cliente = await _repository.LeerClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarCliente(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }
            await _repository.ModificarCliente(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarCliente(id, usuarioModificacion);
            return NoContent();
        }
    }
}
