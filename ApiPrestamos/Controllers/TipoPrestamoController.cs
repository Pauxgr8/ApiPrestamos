using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPrestamoController : ControllerBase
    {
        private readonly TipoPrestamoRepository _repository;

        public TipoPrestamoController(TipoPrestamoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipoPrestamo([FromBody] TipoPrestamo tipoPrestamo)
        {
            await _repository.CrearTipoPrestamo(tipoPrestamo);
            return CreatedAtAction(nameof(BuscarTipoPrestamoPorId), new { id = tipoPrestamo.IdTipoPrestamo }, tipoPrestamo);
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoPrestamo>>> LeerTiposPrestamo()
        {
            return await _repository.LeerTiposPrestamo();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPrestamo>> BuscarTipoPrestamoPorId(int id)
        {
            var tipoPrestamo = await _repository.LeerTipoPrestamoPorId(id);
            if (tipoPrestamo == null)
            {
                return NotFound();
            }
            return tipoPrestamo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarTipoPrestamo(int id, [FromBody] TipoPrestamo tipoPrestamo)
        {
            if (id != tipoPrestamo.IdTipoPrestamo)
            {
                return BadRequest();
            }
            await _repository.ModificarTipoPrestamo(tipoPrestamo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTipoPrestamo(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarTipoPrestamo(id, usuarioModificacion);
            return NoContent();
        }
    }
}
