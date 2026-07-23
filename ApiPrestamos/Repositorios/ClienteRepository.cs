using ApiPrestamos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos.Repositorios
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearCliente(Cliente cliente)
        {
            var parameters = new[]
            {
                new SqlParameter("@Nombre", cliente.Nombre),
                new SqlParameter("@Apellido", cliente.Apellido),
                new SqlParameter("@Correo", cliente.Correo),
                new SqlParameter("@Telefono", cliente.Telefono),
                new SqlParameter("@IdGenero", cliente.IdGenero),
                new SqlParameter("@IdNivelEducativo", cliente.IdNivelEducativo),
                new SqlParameter("@IdRangoEdad", cliente.IdRangoEdad),
                new SqlParameter("@IdRangoIngresos", cliente.IdRangoIngresos),
                new SqlParameter("@UsuarioCreacion", cliente.UsuarioCreacion),
                new SqlParameter("@Activo", cliente.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertarCliente @Nombre, @Apellido, @Correo, @Telefono, @IdGenero, @IdNivelEducativo, @IdRangoEdad, @IdRangoIngresos, @UsuarioCreacion, @Activo", parameters);
        }

        public async Task<List<Cliente>> LeerClientes()
        {
            return await _context.Clientes.FromSqlRaw("EXEC sp_ObtenerClientes").ToListAsync();
        }

        public async Task<Cliente> LeerClientePorId(int id)
        {
            var parameter = new SqlParameter("@IdCliente", id);
            var result = await _context.Clientes.FromSqlRaw("EXEC sp_ObtenerClientePorId @IdCliente", parameter).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task ModificarCliente(Cliente cliente)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdCliente", cliente.IdCliente),
                new SqlParameter("@Nombre", cliente.Nombre),
                new SqlParameter("@Apellido", cliente.Apellido),
                new SqlParameter("@Correo", cliente.Correo),
                new SqlParameter("@Telefono", cliente.Telefono),
                new SqlParameter("@IdGenero", cliente.IdGenero),
                new SqlParameter("@IdNivelEducativo", cliente.IdNivelEducativo),
                new SqlParameter("@IdRangoEdad", cliente.IdRangoEdad),
                new SqlParameter("@IdRangoIngresos", cliente.IdRangoIngresos),
                new SqlParameter("@UsuarioModificacion", cliente.UsuarioModificacion ?? (object)DBNull.Value),
                new SqlParameter("@Activo", cliente.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ActualizarCliente @IdCliente, @Nombre, @Apellido, @Correo, @Telefono, @IdGenero, @IdNivelEducativo, @IdRangoEdad, @IdRangoIngresos, @UsuarioModificacion, @Activo", parameters);
        }

        public async Task EliminarCliente(int id, string usuarioModificacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdCliente", id),
                new SqlParameter("@UsuarioModificacion", usuarioModificacion)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_EliminarCliente @IdCliente, @UsuarioModificacion", parameters);
        }
    }
}
