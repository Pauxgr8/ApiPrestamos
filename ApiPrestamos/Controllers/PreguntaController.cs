using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController : ControllerBase
    {
        private readonly PreguntaRepository _repository;

        public PreguntaController(PreguntaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPregunta([FromBody] Pregunta pregunta)
        {
            await _repository.CrearPregunta(pregunta);
            return CreatedAtAction(nameof(BuscarPreguntaPorId), new { id = pregunta.IdPregunta }, pregunta);
        }

        [HttpGet]
        public async Task<ActionResult<List<Pregunta>>> LeerPreguntas()
        {
            return await _repository.LeerPreguntas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pregunta>> BuscarPreguntaPorId(int id)
        {
            var pregunta = await _repository.LeerPreguntaPorId(id);
            if (pregunta == null)
            {
                return NotFound();
            }
            return pregunta;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarPregunta(int id, [FromBody] Pregunta pregunta)
        {
            if (id != pregunta.IdPregunta)
            {
                return BadRequest();
            }
            await _repository.ModificarPregunta(pregunta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPregunta(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarPregunta(id, usuarioModificacion);
            return NoContent();
        }
    }
}
