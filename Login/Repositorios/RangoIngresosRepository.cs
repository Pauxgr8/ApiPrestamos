using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class RangoIngresosRepository
    {
        private readonly AppDbContext _context;

        public RangoIngresosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearRangoIngresos(RangoIngresos rangoIngresos)
        {
            var parameters = new[]
            {
                new SqlParameter("@IngresoMinimo", rangoIngresos.IngresoMinimo),
                new SqlParameter("@IngresoMaximo", rangoIngresos.IngresoMaximo),
                new SqlParameter("@Descripcion", rangoIngresos.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCreacion", rangoIngresos.UsuarioCreacion),
                new SqlParameter("@Activo", rangoIngresos.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarRangoIngresos @IngresoMinimo, @IngresoMaximo, @Descripcion, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<RangoIngresos>> LeerRangosIngresos()
        {
            return await _context.RangosIngresos.FromSqlRaw("EXEC sp_ObtenerRangosIngresos").ToListAsync();
        }

        public async Task<RangoIngresos> LeerRangoIngresosPorId(int id)
        {
            var parameter = new SqlParameter("@IdRangoIngresos", id);
            var result = await _context.RangosIngresos.FromSqlRaw("EXEC sp_ObtenerRangoIngresosPorId @IdRangoIngresos", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarRangoIngresos(RangoIngresos rangoIngresos)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdRangoIngresos", rangoIngresos.IdRangoIngresos),
                new SqlParameter("@IngresoMinimo", rangoIngresos.IngresoMinimo),
                new SqlParameter("@IngresoMaximo", rangoIngresos.IngresoMaximo),
                new SqlParameter("@Descripcion", rangoIngresos.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioModificacion", rangoIngresos.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", rangoIngresos.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarRangoIngresos @IdRangoIngresos, @IngresoMinimo, @IngresoMaximo, @Descripcion, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarRangoIngresos(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdRangoIngresos", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarRangoIngresos @IdRangoIngresos, @UsuarioModificacion", parameters);
        }
    }
}
