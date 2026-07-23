namespace ApiPrestamos.Models
{
    public class CapacidadPago
    {
        public int IdCapacidadPago { get; set; }
        public decimal PagoMinimo { get; set; }
        public decimal PagoMaximo { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
}
