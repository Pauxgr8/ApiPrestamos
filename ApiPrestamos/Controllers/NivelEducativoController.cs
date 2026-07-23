using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelEducativoController : ControllerBase
    {
        private readonly NivelEducativoRepository _repository;

        public NivelEducativoController(NivelEducativoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearNivelEducativo([FromBody] NivelEducativo nivelEducativo)
        {
            await _repository.CrearNivelEducativo(nivelEducativo);
            return CreatedAtAction(nameof(BuscarNivelEducativoPorId), new { id = nivelEducativo.IdNivelEducativo }, nivelEducativo);
        }

        [HttpGet]
        public async Task<ActionResult<List<NivelEducativo>>> LeerNivelesEducativos()
        {
            return await _repository.LeerNivelesEducativos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NivelEducativo>> BuscarNivelEducativoPorId(int id)
        {
            var nivelEducativo = await _repository.LeerNivelEducativoPorId(id);
            if (nivelEducativo == null)
            {
                return NotFound();
            }
            return nivelEducativo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarNivelEducativo(int id, [FromBody] NivelEducativo nivelEducativo)
        {
            if (id != nivelEducativo.IdNivelEducativo)
            {
                return BadRequest();
            }
            await _repository.ModificarNivelEducativo(nivelEducativo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarNivelEducativo(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarNivelEducativo(id, usuarioModificacion);
            return NoContent();
        }
    }
}
