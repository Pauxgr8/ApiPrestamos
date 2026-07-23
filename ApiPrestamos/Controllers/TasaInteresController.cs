using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasaInteresController : ControllerBase
    {
        private readonly TasaInteresRepository _repository;

        public TasaInteresController(TasaInteresRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTasaInteres([FromBody] TasaInteres tasaInteres)
        {
            await _repository.CrearTasaInteres(tasaInteres);
            return CreatedAtAction(nameof(BuscarTasaInteresPorId), new { id = tasaInteres.IdTasaInteres }, tasaInteres);
        }

        [HttpGet]
        public async Task<ActionResult<List<TasaInteres>>> LeerTasasInteres()
        {
            return await _repository.LeerTasasInteres();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TasaInteres>> BuscarTasaInteresPorId(int id)
        {
            var tasaInteres = await _repository.LeerTasaInteresPorId(id);
            if (tasaInteres == null)
            {
                return NotFound();
            }
            return tasaInteres;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarTasaInteres(int id, [FromBody] TasaInteres tasaInteres)
        {
            if (id != tasaInteres.IdTasaInteres)
            {
                return BadRequest();
            }
            await _repository.ModificarTasaInteres(tasaInteres);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTasaInteres(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarTasaInteres(id, usuarioModificacion);
            return NoContent();
        }
    }
}
