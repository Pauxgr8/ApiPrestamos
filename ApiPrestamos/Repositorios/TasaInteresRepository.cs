using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class TasaInteresRepository
    {
        private readonly AppDbContext _context;

        public TasaInteresRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearTasaInteres(TasaInteres tasaInteres)
        {
            var parameters = new[]
            {
                new SqlParameter("@TasaMinima", tasaInteres.TasaMinima),
                new SqlParameter("@TasaMaxima", tasaInteres.TasaMaxima),
                new SqlParameter("@Descripcion", tasaInteres.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCreacion", tasaInteres.UsuarioCreacion),
                new SqlParameter("@Activo", tasaInteres.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarTasaInteres @TasaMinima, @TasaMaxima, @Descripcion, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<TasaInteres>> LeerTasasInteres()
        {
            return await _context.TasasInteres.FromSqlRaw("EXEC sp_ObtenerTasasInteres").ToListAsync();
        }

        public async Task<TasaInteres> LeerTasaInteresPorId(int id)
        {
            var parameter = new SqlParameter("@IdTasaInteres", id);
            var result = await _context.TasasInteres.FromSqlRaw("EXEC sp_ObtenerTasaInteresPorId @IdTasaInteres", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarTasaInteres(TasaInteres tasaInteres)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdTasaInteres", tasaInteres.IdTasaInteres),
                new SqlParameter("@TasaMinima", tasaInteres.TasaMinima),
                new SqlParameter("@TasaMaxima", tasaInteres.TasaMaxima),
                new SqlParameter("@Descripcion", tasaInteres.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioModificacion", tasaInteres.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", tasaInteres.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarTasaInteres @IdTasaInteres, @TasaMinima, @TasaMaxima, @Descripcion, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarTasaInteres(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdTasaInteres", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarTasaInteres @IdTasaInteres, @UsuarioModificacion", parameters);
        }
    }
}
