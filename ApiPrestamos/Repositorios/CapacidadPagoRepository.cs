using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace ApiPrestamos.Repositorios
{
    public class CapacidadPagoRepository
    {
        private readonly AppDbContext _context;

        public CapacidadPagoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearCapacidadPago(CapacidadPago capacidadPago)
        {
            var parameters = new[]
            {
                new SqlParameter("@PagoMinimo", capacidadPago.PagoMinimo),
                new SqlParameter("@PagoMaximo", capacidadPago.PagoMaximo),
                new SqlParameter("@Descripcion", capacidadPago.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCreacion", capacidadPago.UsuarioCreacion),
                new SqlParameter("@Activo", capacidadPago.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarCapacidadPago @PagoMinimo, @PagoMaximo, @Descripcion, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<CapacidadPago>> LeerCapacidadesPago()
        {
            return await _context.CapacidadesPago.FromSqlRaw("EXEC sp_ObtenerCapacidadesPago").ToListAsync();
        }

        public async Task<CapacidadPago> LeerCapacidadPagoPorId(int id)
        {
            var parameter = new SqlParameter("@IdCapacidadPago", id);
            var result = await _context.CapacidadesPago.FromSqlRaw("EXEC sp_ObtenerCapacidadPagoPorId @IdCapacidadPago", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarCapacidadPago(CapacidadPago capacidadPago)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdCapacidadPago", capacidadPago.IdCapacidadPago),
                new SqlParameter("@PagoMinimo", capacidadPago.PagoMinimo),
                new SqlParameter("@PagoMaximo", capacidadPago.PagoMaximo),
                new SqlParameter("@Descripcion", capacidadPago.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioModificacion", capacidadPago.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", capacidadPago.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarCapacidadPago @IdCapacidadPago, @PagoMinimo, @PagoMaximo, @Descripcion, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarCapacidadPago(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdCapacidadPago", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarCapacidadPago @IdCapacidadPago, @UsuarioModificacion", parameters);
        }
    }
}
