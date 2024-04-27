using ADSProject.Interfaces;
using ADSProject.Repositories;
using Microsoft.EntityFrameworkCore;
using ADSProject.DB;


var builder = WebApplication.CreateBuilder(args);

// Configurando DBContext
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer("name=DefaultConnection"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurando inyeccion de dependencias
builder.Services.AddSingleton<IEstudiante, EsudianteRepository>();
builder.Services.AddSingleton<ICarrera, CarreraRepository>();
builder.Services.AddSingleton<IGrupo, GrupoRepository>();
builder.Services.AddSingleton<IMateria, MateriaRepository>();
builder.Services.AddSingleton<IProfesor, ProfesorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


