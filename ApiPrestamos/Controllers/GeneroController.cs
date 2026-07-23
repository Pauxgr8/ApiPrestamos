using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly GeneroRepository _repository;

        public GeneroController(GeneroRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearGenero([FromBody] Genero genero)
        {
            await _repository.CrearGenero(genero);
            return CreatedAtAction(nameof(BuscarGeneroPorId), new { id = genero.IdGenero }, genero);
        }

        [HttpGet]
        public async Task<ActionResult<List<Genero>>> LeerGeneros()
        {
            return await _repository.LeerGeneros();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> BuscarGeneroPorId(int id)
        {
            var genero = await _repository.LeerGeneroPorId(id);
            if (genero == null)
            {
                return NotFound();
            }
            return genero;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarGenero(int id, [FromBody] Genero genero)
        {
            if (id != genero.IdGenero)
            {
                return BadRequest();
            }
            await _repository.ModificarGenero(genero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarGenero(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarGenero(id, usuarioModificacion);
            return NoContent();
        }
    }
}
