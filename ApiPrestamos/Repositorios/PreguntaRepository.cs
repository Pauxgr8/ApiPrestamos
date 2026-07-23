using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class PreguntaRepository
    {
        private readonly AppDbContext _context;

        public PreguntaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearPregunta(Pregunta pregunta)
        {
            var parameters = new[]
            {
                new SqlParameter("@TextoPregunta", pregunta.TextoPregunta),
                new SqlParameter("@Categoria", pregunta.Categoria),
                new SqlParameter("@TipoControl", pregunta.TipoControl),
                new SqlParameter("@Obligatoria", pregunta.Obligatoria),
                new SqlParameter("@UsuarioCreacion", pregunta.UsuarioCreacion),
                new SqlParameter("@Activo", pregunta.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarPregunta @TextoPregunta, @Categoria, @TipoControl, @Obligatoria, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<Pregunta>> LeerPreguntas()
        {
            return await _context.Preguntas.FromSqlRaw("EXEC sp_ObtenerPreguntas").ToListAsync();
        }

        public async Task<Pregunta> LeerPreguntaPorId(int id)
        {
            var parameter = new SqlParameter("@IdPregunta", id);
            var result = await _context.Preguntas.FromSqlRaw("EXEC sp_ObtenerPreguntaPorId @IdPregunta", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarPregunta(Pregunta pregunta)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdPregunta", pregunta.IdPregunta),
                new SqlParameter("@TextoPregunta", pregunta.TextoPregunta),
                new SqlParameter("@Categoria", pregunta.Categoria),
                new SqlParameter("@TipoControl", pregunta.TipoControl),
                new SqlParameter("@Obligatoria", pregunta.Obligatoria),
                new SqlParameter("@UsuarioModificacion", pregunta.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", pregunta.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarPregunta @IdPregunta, @TextoPregunta, @Categoria, @TipoControl, @Obligatoria, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarPregunta(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdPregunta", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarPregunta @IdPregunta, @UsuarioModificacion", parameters);
        }
    }
}
