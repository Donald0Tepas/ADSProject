using ADSProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ADSProject.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Carrera> carreras { get; set; }
        public DbSet<Grupo> grupos { get; set; }
        public DbSet<Materia> materias { get; set; }
        public DbSet<Profesor> profesores { get; set; }

    }
}