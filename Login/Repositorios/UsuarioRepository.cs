using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearUsuario(Usuarios usuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdRol", usuario.IdRol),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Correo", usuario.Correo),
                new SqlParameter("@Usuario", usuario.Usuario),
                new SqlParameter("@Contrasena", usuario.Contrasena),
                new SqlParameter("@UsuarioCreacion", usuario.UsuarioCreacion),
                new SqlParameter("@Activo", usuario.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarUsuario @IdRol, @Nombre, @Correo, @Usuario, @Contrasena, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<Usuarios>> LeerUsuarios()
        {
            return await _context.Usuarios.FromSqlRaw("EXEC sp_ObtenerUsuarios").ToListAsync();
        }

        public async Task<Usuarios> LeerUsuarioPorId(int id)
        {
            var parameter = new SqlParameter("@IdUsuario", id);
            var result = await _context.Usuarios.FromSqlRaw("EXEC sp_ObtenerUsuarioPorId @IdUsuario", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarUsuario(Usuarios usuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdUsuario", usuario.IdUsuario),
                new SqlParameter("@IdRol", usuario.IdRol),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Correo", usuario.Correo),
                new SqlParameter("@Usuario", usuario.Usuario),
                new SqlParameter("@Contrasena", usuario.Contrasena),
                new SqlParameter("@UsuarioModificacion", usuario.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", usuario.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarUsuario @IdUsuario, @IdRol, @Nombre, @Correo, @Usuario, @Contrasena, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarUsuario(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdUsuario", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarUsuario @IdUsuario, @UsuarioModificacion", parameters);
        }
    }
}
