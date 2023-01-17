
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models;

namespace UniversityApiBackend.DataAcces
{
    public class UniversityContext: DbContext  //el contexto e slo qu enos permite trabajar con la base de datos
    {
        // Creamos un constructor
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }   // debemos poner entre "<>" el tipo de la clase
        
        // add Db Sets (creamos las Tablas de la base de datos)
        public DbSet<User>? User { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapters>? Chapters { get; set; }
        public DbSet<Category>? Categorys { get; set; }
        public DbSet<Student>? Students { get; set; }

    }
}
