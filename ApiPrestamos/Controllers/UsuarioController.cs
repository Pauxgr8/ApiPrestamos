using ApiPrestamos.Models;
using ApiPrestamos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _repository;

        public UsuarioController(UsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuarios usuario)
        {
            await _repository.CrearUsuario(usuario);
            return CreatedAtAction(nameof(BuscarUsuarioPorId), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> LeerUsuarios()
        {
            return await _repository.LeerUsuarios();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> BuscarUsuarioPorId(int id)
        {
            var usuario = await _repository.LeerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarUsuario(int id, [FromBody] Usuarios usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }
            await _repository.ModificarUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id, [FromQuery] string usuarioModificacion)
        {
            await _repository.EliminarUsuario(id, usuarioModificacion);
            return NoContent();
        }
    }
}
