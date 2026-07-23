using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacidadPagoController : ControllerBase
    {
        private readonly CapacidadPagoRepository _repository;

        public CapacidadPagoController(CapacidadPagoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCapacidadPago([FromBody] CapacidadPago capacidadPago)
        {
            await _repository.CrearCapacidadPago(capacidadPago);
            return CreatedAtAction(nameof(BuscarCapacidadPagoPorId), new { id = capacidadPago.IdCapacidadPago }, capacidadPago);
        }

        [HttpGet]
        public async Task<ActionResult<List<CapacidadPago>>> LeerCapacidadesPago()
        {
            return await _repository.LeerCapacidadesPago();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CapacidadPago>> BuscarCapacidadPagoPorId(int id)
        {
            var capacidadPago = await _repository.LeerCapacidadPagoPorId(id);
            if (capacidadPago == null)
            {
                return NotFound();
            }
            return capacidadPago;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarCapacidadPago(int id, [FromBody] CapacidadPago capacidadPago)
        {
            if (id != capacidadPago.IdCapacidadPago)
            {
                return BadRequest();
            }
            await _repository.ModificarCapacidadPago(capacidadPago);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCapacidadPago(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarCapacidadPago(id, usuarioModificacion);
            return NoContent();
        }
    }
}
