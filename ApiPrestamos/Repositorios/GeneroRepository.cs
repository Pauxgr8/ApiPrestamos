using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class GeneroRepository
    {
        private readonly AppDbContext _context;

        public GeneroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearGenero(Genero genero)
        {
            var parameters = new[]
            {
                new SqlParameter("@Nombre", genero.Nombre),
                new SqlParameter("@UsuarioCreacion", genero.UsuarioCreacion),
                new SqlParameter("@Activo", genero.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarGenero @Nombre, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<Genero>> LeerGeneros()
        {
            return await _context.Generos.FromSqlRaw("EXEC sp_ObtenerGeneros").ToListAsync();
        }

        public async Task<Genero> LeerGeneroPorId(int id)
        {
            var parameter = new SqlParameter("@IdGenero", id);
            var result = await _context.Generos.FromSqlRaw("EXEC sp_ObtenerGeneroPorId @IdGenero", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarGenero(Genero genero)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdGenero", genero.IdGenero),
                new SqlParameter("@Nombre", genero.Nombre),
                new SqlParameter("@UsuarioModificacion", genero.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", genero.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarGenero @IdGenero, @Nombre, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarGenero(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdGenero", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarGenero @IdGenero, @UsuarioModificacion", parameters);
        }
    }
}
