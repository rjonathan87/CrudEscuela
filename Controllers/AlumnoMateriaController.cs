using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEscuela.Models;

namespace CrudEscuela.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public AlumnoMateriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: obtenermos todas las materias de los alumnos
        [Produces("application/json")]
        [HttpPost]
        public async Task<JsonResult> GetMateriasByAlumno(int Id)
        {
            var alumnomaterias = _context.AlumnosMaterias
                .Where(a => a.AlumnoId == Id)
                .Include(am => am.Materia)
                .Select(r => new Models.Materia 
                    {
                        Id = r.Materia.Id,
                        NombreMateria = r.Materia.NombreMateria,
                        Activo = r.Materia.Activo,
                        Costo = r.Materia.Costo
                    }
                )
                .ToListAsync();

            return Json(await alumnomaterias);
        }

        public async Task AddMateriaAlumno()
        {

        }

        private bool AlumnoMateriaExists(int id)
        {
            return _context.Materias.Any(e => e.Id == id);
        }
    }
}
