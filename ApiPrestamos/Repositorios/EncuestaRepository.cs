using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class EncuestaRepository
    {
        private readonly AppDbContext _context;

        public EncuestaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearEncuesta(Encuesta encuesta)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdCliente", encuesta.IdCliente),
                new SqlParameter("@IdUsuario", encuesta.IdUsuario),
                new SqlParameter("@IdTipoPrestamo", encuesta.IdTipoPrestamo),
                new SqlParameter("@IdPlazo", encuesta.IdPlazo),
                new SqlParameter("@IdTasaInteres", encuesta.IdTasaInteres),
                new SqlParameter("@IdCapacidadPago", encuesta.IdCapacidadPago),
                new SqlParameter("@IdMedioContratacion", encuesta.IdMedioContratacion),
                new SqlParameter("@UsuarioCreacion", encuesta.UsuarioCreacion),
                new SqlParameter("@Activo", encuesta.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarEncuesta @IdCliente, @IdUsuario, @IdTipoPrestamo, @IdPlazo, @IdTasaInteres, @IdCapacidadPago, @IdMedioContratacion, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<Encuesta>> LeerEncuestas()
        {
            return await _context.Encuestas.FromSqlRaw("EXEC sp_ObtenerEncuestas").ToListAsync();
        }

        public async Task<Encuesta> LeerEncuestaPorId(int id)
        {
            var parameter = new SqlParameter("@IdEncuesta", id);
            var result = await _context.Encuestas.FromSqlRaw("EXEC sp_ObtenerEncuestaPorId @IdEncuesta", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarEncuesta(Encuesta encuesta)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdEncuesta", encuesta.IdEncuesta),
                new SqlParameter("@IdCliente", encuesta.IdCliente),
                new SqlParameter("@IdUsuario", encuesta.IdUsuario),
                new SqlParameter("@IdTipoPrestamo", encuesta.IdTipoPrestamo),
                new SqlParameter("@IdPlazo", encuesta.IdPlazo),
                new SqlParameter("@IdTasaInteres", encuesta.IdTasaInteres),
                new SqlParameter("@IdCapacidadPago", encuesta.IdCapacidadPago),
                new SqlParameter("@IdMedioContratacion", encuesta.IdMedioContratacion),
                new SqlParameter("@UsuarioModificacion", encuesta.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", encuesta.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarEncuesta @IdEncuesta, @IdCliente, @IdUsuario, @IdTipoPrestamo, @IdPlazo, @IdTasaInteres, @IdCapacidadPago, @IdMedioContratacion, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarEncuesta(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdEncuesta", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarEncuesta @IdEncuesta, @UsuarioModificacion", parameters);
        }
    }
}
