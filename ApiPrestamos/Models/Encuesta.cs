namespace ApiPrestamos.Models
{
    public class Encuesta
    {
        public int IdEncuesta { get; set; }
        public DateTime FechaEncuesta { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoPrestamo { get; set; }
        public int IdPlazo { get; set; }
        public int IdTasaInteres { get; set; }
        public int IdCapacidadPago { get; set; }
        public int IdMedioContratacion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
}
