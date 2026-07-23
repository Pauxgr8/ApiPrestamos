using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioContratacionController : ControllerBase
    {
        private readonly MedioContratacionRepository _repository;

        public MedioContratacionController(MedioContratacionRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearMedioContratacion([FromBody] MedioContratacion medioContratacion)
        {
            await _repository.CrearMedioContratacion(medioContratacion);
            return CreatedAtAction(nameof(BuscarMedioContratacionPorId), new { id = medioContratacion.IdMedioContratacion }, medioContratacion);
        }

        [HttpGet]
        public async Task<ActionResult<List<MedioContratacion>>> LeerMediosContratacion()
        {
            return await _repository.LeerMediosContratacion();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedioContratacion>> BuscarMedioContratacionPorId(int id)
        {
            var medioContratacion = await _repository.LeerMedioContratacionPorId(id);
            if (medioContratacion == null)
            {
                return NotFound();
            }
            return medioContratacion;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarMedioContratacion(int id, [FromBody] MedioContratacion medioContratacion)
        {
            if (id != medioContratacion.IdMedioContratacion)
            {
                return BadRequest();
            }
            await _repository.ModificarMedioContratacion(medioContratacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMedioContratacion(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarMedioContratacion(id, usuarioModificacion);
            return NoContent();
        }
    }
}
