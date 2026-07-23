using ApiPrestamos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPrestamos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        { }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<NivelEducativo> NivelesEducativos { get; set; }
        public DbSet<RangoEdad> RangosEdad { get; set; }
        public DbSet<RangoIngresos> RangosIngresos { get; set; }
        public DbSet<TipoPrestamo> TiposPrestamo { get; set; }
        public DbSet<Plazo> Plazos { get; set; }
        public DbSet<TasaInteres> TasasInteres { get; set; }
        public DbSet<CapacidadPago> CapacidadesPago { get; set; }
        public DbSet<MedioContratacion> MediosContratacion { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la tabla Rol
            modelBuilder.Entity<Rol>()
                .ToTable("Rol")
                .HasKey(r => r.IdRol);

            // Configuración de la tabla Genero
            modelBuilder.Entity<Genero>()
                .ToTable("Genero")
                .HasKey(g => g.IdGenero);

            // Configuración de la tabla NivelEducativo
            modelBuilder.Entity<NivelEducativo>()
                .ToTable("NivelEducativo")
                .HasKey(ne => ne.IdNivelEducativo);

            // Configuración de la tabla RangoEdad
            modelBuilder.Entity<RangoEdad>()
                .ToTable("RangoEdad")
                .HasKey(re => re.IdRangoEdad);

            // Configuración de la tabla RangoIngresos
            modelBuilder.Entity<RangoIngresos>()
                .ToTable("RangoIngresos")
                .HasKey(ri => ri.IdRangoIngresos);

            // Configuración de la tabla TipoPrestamo
            modelBuilder.Entity<TipoPrestamo>()
                .ToTable("TipoPrestamo")
                .HasKey(tp => tp.IdTipoPrestamo);

            // Configuración de la tabla Plazo
            modelBuilder.Entity<Plazo>()
                .ToTable("Plazo")
                .HasKey(p => p.IdPlazo);

            // Configuración de la tabla TasaInteres
            modelBuilder.Entity<TasaInteres>()
                .ToTable("TasaInteres")
                .HasKey(ti => ti.IdTasaInteres);

            // Configuración de la tabla CapacidadPago
            modelBuilder.Entity<CapacidadPago>()
                .ToTable("CapacidadPago")
                .HasKey(cp => cp.IdCapacidadPago);

            // Configuración de la tabla MedioContratacion
            modelBuilder.Entity<MedioContratacion>()
                .ToTable("MedioContratacion")
                .HasKey(mc => mc.IdMedioContratacion);

            // Configuración de la tabla Usuario
            modelBuilder.Entity<Usuarios>()
                .ToTable("Usuario")
                .HasKey(u => u.IdUsuario);

            // Configuración de la relación Usuario - Rol
            modelBuilder.Entity<Usuarios>()
                .HasOne<Rol>()
                .WithMany()
                .HasForeignKey(u => u.IdRol)
                .HasConstraintName("FK_Usuario_Rol");

            // Configuración de la tabla Cliente
            modelBuilder.Entity<Cliente>()
                .ToTable("Cliente")
                .HasKey(c => c.IdCliente);

            // Configuración de la relación Cliente - Genero
            modelBuilder.Entity<Cliente>()
                .HasOne<Genero>()
                .WithMany()
                .HasForeignKey(c => c.IdGenero)
                .HasConstraintName("FK_Cliente_Genero");

            // Configuración de la relación Cliente - NivelEducativo
            modelBuilder.Entity<Cliente>()
                .HasOne<NivelEducativo>()
                .WithMany()
                .HasForeignKey(c => c.IdNivelEducativo)
                .HasConstraintName("FK_Cliente_NivelEducativo");

            // Configuración de la relación Cliente - RangoEdad
            modelBuilder.Entity<Cliente>()
                .HasOne<RangoEdad>()
                .WithMany()
                .HasForeignKey(c => c.IdRangoEdad)
                .HasConstraintName("FK_Cliente_RangoEdad");

            // Configuración de la relación Cliente - RangoIngresos
            modelBuilder.Entity<Cliente>()
                .HasOne<RangoIngresos>()
                .WithMany()
                .HasForeignKey(c => c.IdRangoIngresos)
                .HasConstraintName("FK_Cliente_RangoIngresos");

            // Configuración de la tabla Pregunta
            modelBuilder.Entity<Pregunta>()
                .ToTable("Pregunta")
                .HasKey(p => p.IdPregunta);

            // Configuración de la tabla Encuesta
            modelBuilder.Entity<Encuesta>()
                .ToTable("Encuesta")
                .HasKey(e => e.IdEncuesta);

            // Configuración de la relación Encuesta - Cliente
            modelBuilder.Entity<Encuesta>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(e => e.IdCliente)
                .HasConstraintName("FK_Encuesta_Cliente");

            // Configuración de la relación Encuesta - Usuario
            modelBuilder.Entity<Encuesta>()
                .HasOne<Usuarios>()
                .WithMany()
                .HasForeignKey(e => e.IdUsuario)
                .HasConstraintName("FK_Encuesta_Usuario");

            // Configuración de la relación Encuesta - TipoPrestamo
            modelBuilder.Entity<Encuesta>()
                .HasOne<TipoPrestamo>()
                .WithMany()
                .HasForeignKey(e => e.IdTipoPrestamo)
                .HasConstraintName("FK_Encuesta_TipoPrestamo");

            // Configuración de la relación Encuesta - Plazo
            modelBuilder.Entity<Encuesta>()
                .HasOne<Plazo>()
                .WithMany()
                .HasForeignKey(e => e.IdPlazo)
                .HasConstraintName("FK_Encuesta_Plazo");

            // Configuración de la relación Encuesta - TasaInteres
            modelBuilder.Entity<Encuesta>()
                .HasOne<TasaInteres>()
                .WithMany()
                .HasForeignKey(e => e.IdTasaInteres)
                .HasConstraintName("FK_Encuesta_TasaInteres");

            // Configuración de la relación Encuesta - CapacidadPago
            modelBuilder.Entity<Encuesta>()
                .HasOne<CapacidadPago>()
                .WithMany()
                .HasForeignKey(e => e.IdCapacidadPago)
                .HasConstraintName("FK_Encuesta_CapacidadPago");

            // Configuración de la relación Encuesta - MedioContratacion
            modelBuilder.Entity<Encuesta>()
                .HasOne<MedioContratacion>()
                .WithMany()
                .HasForeignKey(e => e.IdMedioContratacion)
                .HasConstraintName("FK_Encuesta_MedioContratacion");

            // Configuración de la tabla Respuesta
            modelBuilder.Entity<Respuesta>()
                .ToTable("Respuesta")
                .HasKey(r => r.IdRespuesta);

            // Configuración de la relación Respuesta - Encuesta
            modelBuilder.Entity<Respuesta>()
                .HasOne<Encuesta>()
                .WithMany()
                .HasForeignKey(r => r.IdEncuesta)
                .HasConstraintName("FK_Respuesta_Encuesta");

            // Configuración de la relación Respuesta - Pregunta
            modelBuilder.Entity<Respuesta>()
                .HasOne<Pregunta>()
                .WithMany()
                .HasForeignKey(r => r.IdPregunta)
                .HasConstraintName("FK_Respuesta_Pregunta");
        }
    }
}
