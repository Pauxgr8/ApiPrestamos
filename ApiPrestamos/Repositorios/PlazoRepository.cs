using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class PlazoRepository
    {
        private readonly AppDbContext _context;

        public PlazoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearPlazo(Plazo plazo)
        {
            var parameters = new[]
            {
                new SqlParameter("@Meses", plazo.Meses),
                new SqlParameter("@Descripcion", plazo.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCreacion", plazo.UsuarioCreacion),
                new SqlParameter("@Activo", plazo.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarPlazo @Meses, @Descripcion, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<Plazo>> LeerPlazos()
        {
            return await _context.Plazos.FromSqlRaw("EXEC sp_ObtenerPlazos").ToListAsync();
        }

        public async Task<Plazo> LeerPlazoPorId(int id)
        {
            var parameter = new SqlParameter("@IdPlazo", id);
            var result = await _context.Plazos.FromSqlRaw("EXEC sp_ObtenerPlazoPorId @IdPlazo", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarPlazo(Plazo plazo)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdPlazo", plazo.IdPlazo),
                new SqlParameter("@Meses", plazo.Meses),
                new SqlParameter("@Descripcion", plazo.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioModificacion", plazo.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", plazo.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarPlazo @IdPlazo, @Meses, @Descripcion, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarPlazo(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdPlazo", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarPlazo @IdPlazo, @UsuarioModificacion", parameters);
        }
    }
}
