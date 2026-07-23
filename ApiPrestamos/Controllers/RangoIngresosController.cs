using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangoIngresosController : ControllerBase
    {
        private readonly RangoIngresosRepository _repository;

        public RangoIngresosController(RangoIngresosRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRangoIngresos([FromBody] RangoIngresos rangoIngresos)
        {
            await _repository.CrearRangoIngresos(rangoIngresos);
            return CreatedAtAction(nameof(BuscarRangoIngresosPorId), new { id = rangoIngresos.IdRangoIngresos }, rangoIngresos);
        }

        [HttpGet]
        public async Task<ActionResult<List<RangoIngresos>>> LeerRangosIngresos()
        {
            return await _repository.LeerRangosIngresos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RangoIngresos>> BuscarRangoIngresosPorId(int id)
        {
            var rangoIngresos = await _repository.LeerRangoIngresosPorId(id);
            if (rangoIngresos == null)
            {
                return NotFound();
            }
            return rangoIngresos;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarRangoIngresos(int id, [FromBody] RangoIngresos rangoIngresos)
        {
            if (id != rangoIngresos.IdRangoIngresos)
            {
                return BadRequest();
            }
            await _repository.ModificarRangoIngresos(rangoIngresos);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRangoIngresos(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarRangoIngresos(id, usuarioModificacion);
            return NoContent();
        }
    }
}
