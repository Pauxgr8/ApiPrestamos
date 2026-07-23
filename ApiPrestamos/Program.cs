using ApiPrestamos;
using ApiPrestamos.Repositorios;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de Repositorios
builder.Services.AddScoped<RolRepository>();
builder.Services.AddScoped<GeneroRepository>();
builder.Services.AddScoped<NivelEducativoRepository>();
builder.Services.AddScoped<RangoEdadRepository>();
builder.Services.AddScoped<RangoIngresosRepository>();
builder.Services.AddScoped<TipoPrestamoRepository>();
builder.Services.AddScoped<PlazoRepository>();
builder.Services.AddScoped<TasaInteresRepository>();
builder.Services.AddScoped<CapacidadPagoRepository>();
builder.Services.AddScoped<MedioContratacionRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<PreguntaRepository>();
builder.Services.AddScoped<EncuestaRepository>();
builder.Services.AddScoped<RespuestaRepository>();

builder.Services.AddControllers();

// Configuración de OpenAPI si es necesario
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Sistema Cotización Préstamos v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();