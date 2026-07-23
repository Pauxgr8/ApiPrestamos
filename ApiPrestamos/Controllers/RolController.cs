using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolRepository _repository;

        public RolController(RolRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol([FromBody] Rol rol)
        {
            await _repository.CrearRol(rol);
            return CreatedAtAction(nameof(BuscarRolPorId), new { id = rol.IdRol }, rol);
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> LeerRoles()
        {
            return await _repository.LeerRoles();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> BuscarRolPorId(int id)
        {
            var rol = await _repository.LeerRolPorId(id);
            if (rol == null)
            {
                return NotFound();
            }
            return rol;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarRol(int id, [FromBody] Rol rol)
        {
            if (id != rol.IdRol)
            {
                return BadRequest();
            }
            await _repository.ModificarRol(rol);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRol(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarRol(id, usuarioModificacion);
            return NoContent();
        }
    }
}
