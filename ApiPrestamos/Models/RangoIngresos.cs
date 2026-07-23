namespace ApiPrestamos.Models
{
    public class RangoIngresos
    {
        public int IdRangoIngresos { get; set; }
        public decimal IngresoMinimo { get; set; }
        public decimal IngresoMaximo { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
}
