using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly EncuestaRepository _repository;

        public EncuestaController(EncuestaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearEncuesta([FromBody] Encuesta encuesta)
        {
            await _repository.CrearEncuesta(encuesta);
            return CreatedAtAction(nameof(BuscarEncuestaPorId), new { id = encuesta.IdEncuesta }, encuesta);
        }

        [HttpGet]
        public async Task<ActionResult<List<Encuesta>>> LeerEncuestas()
        {
            return await _repository.LeerEncuestas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Encuesta>> BuscarEncuestaPorId(int id)
        {
            var encuesta = await _repository.LeerEncuestaPorId(id);
            if (encuesta == null)
            {
                return NotFound();
            }
            return encuesta;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarEncuesta(int id, [FromBody] Encuesta encuesta)
        {
            if (id != encuesta.IdEncuesta)
            {
                return BadRequest();
            }
            await _repository.ModificarEncuesta(encuesta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEncuesta(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarEncuesta(id, usuarioModificacion);
            return NoContent();
        }
    }
}
