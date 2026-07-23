namespace ApiPrestamos.Models
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public int IdEncuesta { get; set; }
        public int IdPregunta { get; set; }
        public string Valor { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
}
