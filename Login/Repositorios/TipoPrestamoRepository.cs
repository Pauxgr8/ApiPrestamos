using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class TipoPrestamoRepository
    {
        private readonly AppDbContext _context;

        public TipoPrestamoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearTipoPrestamo(TipoPrestamo tipoPrestamo)
        {
            var parameters = new[]
            {
                new SqlParameter("@Nombre", tipoPrestamo.Nombre),
                new SqlParameter("@Descripcion", tipoPrestamo.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCreacion", tipoPrestamo.UsuarioCreacion),
                new SqlParameter("@Activo", tipoPrestamo.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarTipoPrestamo @Nombre, @Descripcion, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<TipoPrestamo>> LeerTiposPrestamo()
        {
            return await _context.TiposPrestamo.FromSqlRaw("EXEC sp_ObtenerTiposPrestamo").ToListAsync();
        }

        public async Task<TipoPrestamo> LeerTipoPrestamoPorId(int id)
        {
            var parameter = new SqlParameter("@IdTipoPrestamo", id);
            var result = await _context.TiposPrestamo.FromSqlRaw("EXEC sp_ObtenerTipoPrestamoPorId @IdTipoPrestamo", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarTipoPrestamo(TipoPrestamo tipoPrestamo)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdTipoPrestamo", tipoPrestamo.IdTipoPrestamo),
                new SqlParameter("@Nombre", tipoPrestamo.Nombre),
                new SqlParameter("@Descripcion", tipoPrestamo.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioModificacion", tipoPrestamo.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", tipoPrestamo.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarTipoPrestamo @IdTipoPrestamo, @Nombre, @Descripcion, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarTipoPrestamo(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdTipoPrestamo", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarTipoPrestamo @IdTipoPrestamo, @UsuarioModificacion", parameters);
        }
    }
}
