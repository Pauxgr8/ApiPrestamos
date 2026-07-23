using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangoEdadController : ControllerBase
    {
        private readonly RangoEdadRepository _repository;

        public RangoEdadController(RangoEdadRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRangoEdad([FromBody] RangoEdad rangoEdad)
        {
            await _repository.CrearRangoEdad(rangoEdad);
            return CreatedAtAction(nameof(BuscarRangoEdadPorId), new { id = rangoEdad.IdRangoEdad }, rangoEdad);
        }

        [HttpGet]
        public async Task<ActionResult<List<RangoEdad>>> LeerRangosEdad()
        {
            return await _repository.LeerRangosEdad();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RangoEdad>> BuscarRangoEdadPorId(int id)
        {
            var rangoEdad = await _repository.LeerRangoEdadPorId(id);
            if (rangoEdad == null)
            {
                return NotFound();
            }
            return rangoEdad;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarRangoEdad(int id, [FromBody] RangoEdad rangoEdad)
        {
            if (id != rangoEdad.IdRangoEdad)
            {
                return BadRequest();
            }
            await _repository.ModificarRangoEdad(rangoEdad);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRangoEdad(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarRangoEdad(id, usuarioModificacion);
            return NoContent();
        }
    }
}
