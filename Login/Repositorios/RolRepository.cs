using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class RolRepository
    {
        private readonly AppDbContext _context;

        public RolRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearRol(Rol rol)
        {
            var parameters = new[]
            {
                new SqlParameter("@Nombre", rol.Nombre),
                new SqlParameter("@Descripcion", rol.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCreacion", rol.UsuarioCreacion),
                new SqlParameter("@Activo", rol.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarRol @Nombre, @Descripcion, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<Rol>> LeerRoles()
        {
            return await _context.Roles.FromSqlRaw("EXEC sp_ObtenerRoles").ToListAsync();
        }

        public async Task<Rol> LeerRolPorId(int id)
        {
            var parameter = new SqlParameter("@IdRol", id);
            var result = await _context.Roles.FromSqlRaw("EXEC sp_ObtenerRolPorId @IdRol", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarRol(Rol rol)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdRol", rol.IdRol),
                new SqlParameter("@Nombre", rol.Nombre),
                new SqlParameter("@Descripcion", rol.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioModificacion", rol.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", rol.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarRol @IdRol, @Nombre, @Descripcion, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarRol(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdRol", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarRol @IdRol, @UsuarioModificacion", parameters);
        }
    }
}
