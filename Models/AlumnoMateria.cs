using System.ComponentModel.DataAnnotations;

namespace CrudEscuela.Models
{
    public class AlumnoMateria
    {
        public int AlumnoId { get; set; }
        public int MateriaId { get; set; }
        //Propiedades navigacionales
        public Alumno Alumno { get; set; }
        public Materia Materia { get; set; }
    }
}