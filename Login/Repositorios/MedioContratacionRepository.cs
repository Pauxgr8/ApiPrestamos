using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class MedioContratacionRepository
    {
        private readonly AppDbContext _context;

        public MedioContratacionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearMedioContratacion(MedioContratacion medioContratacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@Nombre", medioContratacion.Nombre),
                new SqlParameter("@Descripcion", medioContratacion.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCreacion", medioContratacion.UsuarioCreacion),
                new SqlParameter("@Activo", medioContratacion.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarMedioContratacion @Nombre, @Descripcion, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<MedioContratacion>> LeerMediosContratacion()
        {
            return await _context.MediosContratacion.FromSqlRaw("EXEC sp_ObtenerMediosContratacion").ToListAsync();
        }

        public async Task<MedioContratacion> LeerMedioContratacionPorId(int id)
        {
            var parameter = new SqlParameter("@IdMedioContratacion", id);
            var result = await _context.MediosContratacion.FromSqlRaw("EXEC sp_ObtenerMedioContratacionPorId @IdMedioContratacion", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarMedioContratacion(MedioContratacion medioContratacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdMedioContratacion", medioContratacion.IdMedioContratacion),
                new SqlParameter("@Nombre", medioContratacion.Nombre),
                new SqlParameter("@Descripcion", medioContratacion.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioModificacion", medioContratacion.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", medioContratacion.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarMedioContratacion @IdMedioContratacion, @Nombre, @Descripcion, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarMedioContratacion(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdMedioContratacion", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarMedioContratacion @IdMedioContratacion, @UsuarioModificacion", parameters);
        }
    }
}
