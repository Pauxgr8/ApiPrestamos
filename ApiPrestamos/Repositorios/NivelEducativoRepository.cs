using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class NivelEducativoRepository
    {
        private readonly AppDbContext _context;

        public NivelEducativoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearNivelEducativo(NivelEducativo nivelEducativo)
        {
            var parameters = new[]
            {
                new SqlParameter("@Nombre", nivelEducativo.Nombre),
                new SqlParameter("@UsuarioCreacion", nivelEducativo.UsuarioCreacion),
                new SqlParameter("@Activo", nivelEducativo.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarNivelEducativo @Nombre, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<NivelEducativo>> LeerNivelesEducativos()
        {
            return await _context.NivelesEducativos.FromSqlRaw("EXEC sp_ObtenerNivelesEducativos").ToListAsync();
        }

        public async Task<NivelEducativo> LeerNivelEducativoPorId(int id)
        {
            var parameter = new SqlParameter("@IdNivelEducativo", id);
            var result = await _context.NivelesEducativos.FromSqlRaw("EXEC sp_ObtenerNivelEducativoPorId @IdNivelEducativo", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarNivelEducativo(NivelEducativo nivelEducativo)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdNivelEducativo", nivelEducativo.IdNivelEducativo),
                new SqlParameter("@Nombre", nivelEducativo.Nombre),
                new SqlParameter("@UsuarioModificacion", nivelEducativo.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", nivelEducativo.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarNivelEducativo @IdNivelEducativo, @Nombre, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarNivelEducativo(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdNivelEducativo", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarNivelEducativo @IdNivelEducativo, @UsuarioModificacion", parameters);
        }
    }
}
