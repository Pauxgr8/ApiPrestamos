using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlazoController : ControllerBase
    {
        private readonly PlazoRepository _repository;

        public PlazoController(PlazoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPlazo([FromBody] Plazo plazo)
        {
            await _repository.CrearPlazo(plazo);
            return CreatedAtAction(nameof(BuscarPlazoPorId), new { id = plazo.IdPlazo }, plazo);
        }

        [HttpGet]
        public async Task<ActionResult<List<Plazo>>> LeerPlazos()
        {
            return await _repository.LeerPlazos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plazo>> BuscarPlazoPorId(int id)
        {
            var plazo = await _repository.LeerPlazoPorId(id);
            if (plazo == null)
            {
                return NotFound();
            }
            return plazo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarPlazo(int id, [FromBody] Plazo plazo)
        {
            if (id != plazo.IdPlazo)
            {
                return BadRequest();
            }
            await _repository.ModificarPlazo(plazo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPlazo(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarPlazo(id, usuarioModificacion);
            return NoContent();
        }
    }
}
