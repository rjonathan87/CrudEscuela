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

        [HttpPost]
        public ActionResult AddAlumnoMateria(AlumnoMateria am)
        {
            // _context.AlumnosMaterias.Add(am);
            // _context.SaveChanges();
            // string message = "Agregado correctamente";
            return Json( am );
        }

        // public async Task<ActionResult> AddAlumnoMateria(int AlumnoId, int MateriaId)
        // {
        //     if (!AlumnoMateriaExists(AlumnoId, MateriaId))
        //     {
        //         // var alumnoMateriaExists = _context.AlumnosMaterias
        //         //     .Where(x => x.AlumnoId == AlumnoId && x.MateriaId == MateriaId)
        //         //     .ToListAsync();
        //         // return Json(await alumnoMateriaExists);
        //         _context.Add(alumno);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     else{
        //         return Ok();
        //     }
        // }

        private bool AlumnoMateriaExists(int AlumnoId, int MateriaId)
        {
            return _context.AlumnosMaterias.Any(e => e.AlumnoId == AlumnoId && e.MateriaId == MateriaId);
        }
    }
}
