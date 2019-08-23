using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudEscuela.Models
{
    public class Materia
    {
        public int Id { get; set; }

        [Display(Name="Materia")]
        [Required(ErrorMessage="Debes agregar una {0}")]
        [MaxLength(50,ErrorMessage="{0} debe contener menos de 50 caractéres")]
        public string NombreMateria { get; set; }

        [Display(Name="Costo")]
        [RegularExpression(@"^\d+.\d{0,2}$",ErrorMessage = "{0} debe contener el siguiente formato 0.00")]
        public decimal Costo { get; set; }

        public bool Activo { get; set; }

        //Propiedades Navigacionales
        public List<AlumnoMateria> AlumnosMaterias { get; set; }
    }
}