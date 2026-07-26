using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class RangoEdadRepository
    {
        private readonly AppDbContext _context;

        public RangoEdadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearRangoEdad(RangoEdad rangoEdad)
        {
            var parameters = new[]
            {
                new SqlParameter("@EdadMinima", rangoEdad.EdadMinima),
                new SqlParameter("@EdadMaxima", rangoEdad.EdadMaxima),
                new SqlParameter("@Descripcion", rangoEdad.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCreacion", rangoEdad.UsuarioCreacion),
                new SqlParameter("@Activo", rangoEdad.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarRangoEdad @EdadMinima, @EdadMaxima, @Descripcion, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<RangoEdad>> LeerRangosEdad()
        {
            return await _context.RangosEdad.FromSqlRaw("EXEC sp_ObtenerRangosEdad").ToListAsync();
        }

        public async Task<RangoEdad> LeerRangoEdadPorId(int id)
        {
            var parameter = new SqlParameter("@IdRangoEdad", id);
            var result = await _context.RangosEdad.FromSqlRaw("EXEC sp_ObtenerRangoEdadPorId @IdRangoEdad", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarRangoEdad(RangoEdad rangoEdad)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdRangoEdad", rangoEdad.IdRangoEdad),
                new SqlParameter("@EdadMinima", rangoEdad.EdadMinima),
                new SqlParameter("@EdadMaxima", rangoEdad.EdadMaxima),
                new SqlParameter("@Descripcion", rangoEdad.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioModificacion", rangoEdad.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", rangoEdad.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarRangoEdad @IdRangoEdad, @EdadMinima, @EdadMaxima, @Descripcion, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarRangoEdad(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdRangoEdad", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarRangoEdad @IdRangoEdad, @UsuarioModificacion", parameters);
        }
    }
}
