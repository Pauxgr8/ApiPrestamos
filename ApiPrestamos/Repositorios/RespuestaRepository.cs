using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class RespuestaRepository
    {
        private readonly AppDbContext _context;

        public RespuestaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearRespuesta(Respuesta respuesta)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdEncuesta", respuesta.IdEncuesta),
                new SqlParameter("@IdPregunta", respuesta.IdPregunta),
                new SqlParameter("@Valor", respuesta.Valor),
                new SqlParameter("@UsuarioCreacion", respuesta.UsuarioCreacion),
                new SqlParameter("@Activo", respuesta.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarRespuesta @IdEncuesta, @IdPregunta, @Valor, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<Respuesta>> LeerRespuestas()
        {
            return await _context.Respuestas.FromSqlRaw("EXEC sp_ObtenerRespuestas").ToListAsync();
        }

        public async Task<Respuesta> LeerRespuestaPorId(int id)
        {
            var parameter = new SqlParameter("@IdRespuesta", id);
            var result = await _context.Respuestas.FromSqlRaw("EXEC sp_ObtenerRespuestaPorId @IdRespuesta", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<List<Respuesta>> LeerRespuestasPorEncuesta(int idEncuesta)
        {
            var parameter = new SqlParameter("@IdEncuesta", idEncuesta);
            return await _context.Respuestas.FromSqlRaw("EXEC sp_ObtenerRespuestasPorEncuesta @IdEncuesta", parameter).ToListAsync();
        }

        public async Task ModificarRespuesta(Respuesta respuesta)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdRespuesta", respuesta.IdRespuesta),
                new SqlParameter("@IdEncuesta", respuesta.IdEncuesta),
                new SqlParameter("@IdPregunta", respuesta.IdPregunta),
                new SqlParameter("@Valor", respuesta.Valor),
                new SqlParameter("@UsuarioModificacion", respuesta.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", respuesta.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarRespuesta @IdRespuesta, @IdEncuesta, @IdPregunta, @Valor, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarRespuesta(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdRespuesta", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarRespuesta @IdRespuesta, @UsuarioModificacion", parameters);
        }
    }
}
