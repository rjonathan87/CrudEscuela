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
            var alumno = _context.Alumnos
                
                .Where(a => a.Id == Id)

                .Include(am => am.AlumnosMaterias)
                
                .ThenInclude(m => m.Materia)
                
                .AsNoTracking()

                .ToListAsync();

            return Json(await alumno);

        }


        private bool AlumnoMateriaExists(int id)
        {
            return _context.Materias.Any(e => e.Id == id);
        }
    }
}
