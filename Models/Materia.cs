using System.ComponentModel.DataAnnotations;

namespace ex.Models
{
    public class Materia
    {
        public int Id { get; set; }

        [Display(Name="Materia")]
        [Required(ErrorMessage="Debes agregar una {0}")]
        [MaxLength(50,ErrorMessage="{0} debe contener menos de 50 caractéres")]
        public string NombreMateria { get; set; }

        public bool Activo { get; set; }
    }
}