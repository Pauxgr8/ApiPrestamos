namespace ApiPrestamos.Models
{
    public class Pregunta
    {
        public int IdPregunta { get; set; }
        public string TextoPregunta { get; set; }
        public string Categoria { get; set; }
        public string TipoControl { get; set; }
        public bool Obligatoria { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
}
