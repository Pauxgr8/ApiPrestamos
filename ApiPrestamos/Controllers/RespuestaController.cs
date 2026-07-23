using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {
        private readonly RespuestaRepository _repository;

        public RespuestaController(RespuestaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRespuesta([FromBody] Respuesta respuesta)
        {
            await _repository.CrearRespuesta(respuesta);
            return CreatedAtAction(nameof(BuscarRespuestaPorId), new { id = respuesta.IdRespuesta }, respuesta);
        }

        [HttpGet]
        public async Task<ActionResult<List<Respuesta>>> LeerRespuestas()
        {
            return await _repository.LeerRespuestas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Respuesta>> BuscarRespuestaPorId(int id)
        {
            var respuesta = await _repository.LeerRespuestaPorId(id);
            if (respuesta == null)
            {
                return NotFound();
            }
            return respuesta;
        }

        [HttpGet("PorEncuesta/{idEncuesta}")]
        public async Task<ActionResult<List<Respuesta>>> LeerRespuestasPorEncuesta(int idEncuesta)
        {
            return await _repository.LeerRespuestasPorEncuesta(idEncuesta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarRespuesta(int id, [FromBody] Respuesta respuesta)
        {
            if (id != respuesta.IdRespuesta)
            {
                return BadRequest();
            }
            await _repository.ModificarRespuesta(respuesta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRespuesta(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarRespuesta(id, usuarioModificacion);
            return NoContent();
        }
    }
}
