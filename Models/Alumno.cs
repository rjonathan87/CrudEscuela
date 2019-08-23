using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudEscuela.Models
{ 
    public class Alumno
    {
        public int Id { get; set; }

        [Display(Name="Nombre del alumno")]
        [Required(ErrorMessage="Debes agregar un {0}")]
        [MaxLength(50,ErrorMessage="{0} debe contener menos de 50 caractéres")]
        public string Nombre { get; set; }

        [Display(Name="Apellido Paterno")]
        [Required(ErrorMessage="Debes agregar un {0}")]
        [MaxLength(50,ErrorMessage="{0} debe contener menos de 50 caractéres")]
        public string ApellidoPaterno { get; set; }

        [Display(Name="Apellido Materno")]
        [Required(ErrorMessage="Debes agregar un {0}")]
        [MaxLength(50,ErrorMessage="{0} debe contener menos de 50 caractéres")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage="{0} es requerido")]
        [Range(0, 115, ErrorMessage = "{0} no debe ser menor de 0 ni mayor que 115")]
        public int Edad { get; set; }

        [Display(Name="Matrícula del alumno")]
        [Required(ErrorMessage="Debes agregar una {0}")]
        public string Matricula { get; set; }

        [Display(Name="Correo Electrónico")]
        [Required(ErrorMessage="Debes agregar un {0}")]
        public string CorreoElectronico { get; set; }

        public List<AlumnoMateria> AlumnosMaterias { get; set; }
    }
}