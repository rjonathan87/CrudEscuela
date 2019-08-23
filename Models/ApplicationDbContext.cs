using Microsoft.EntityFrameworkCore;


namespace CrudEscuela.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //indicamos que las dos llaves son una llave compuesta
            modelBuilder.Entity<AlumnoMateria>().HasKey(x => new { x.MateriaId, x.AlumnoId } );
            
            modelBuilder.Entity<AlumnoMateria>()
                        .HasOne(x => x.Materia)
                        .WithMany(b => b.AlumnosMaterias)
                        .HasForeignKey(bc => bc.MateriaId);  

            modelBuilder.Entity<AlumnoMateria>()
                .HasOne(bc => bc.Materia)
                .WithMany(c => c.AlumnosMaterias)
                .HasForeignKey(bc => bc.MateriaId);
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }

        //Tabla para relación muchos a muchos
        public virtual DbSet<AlumnoMateria> AlumnosMaterias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

    }
}
