using System.Linq;
using System.Threading.Tasks;
using CrudEscuela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudEscuela.Controllers {
    public class AlumnoMateriaController : Controller {
        private readonly ApplicationDbContext _context;

        public AlumnoMateriaController (ApplicationDbContext context) {
            _context = context;
        }

        // GET: obtenermos todas las materias de los alumnos
        [Produces ("application/json")]
        [HttpPost]
        public async Task<JsonResult> GetMateriasByAlumno (int Id) {
            var alumnomaterias = _context.AlumnosMaterias
                .Where (a => a.AlumnoId == Id)
                .Include (am => am.Materia)
                .Select (r => new Models.Materia {
                    Id = r.Materia.Id,
                        NombreMateria = r.Materia.NombreMateria,
                        Activo = r.Materia.Activo,
                        Costo = r.Materia.Costo
                })
                .ToListAsync ();

            return Json (await alumnomaterias);
        }

        //POST: AlumnoMateria
        [HttpPost]
        public async Task<ActionResult> PostAlumnoMateria (AlumnoMateria alumnosMaterias) {
            _context.AlumnosMaterias.Add (alumnosMaterias);

            try {
                await _context.SaveChangesAsync ();
            } catch (DbUpdateException) {
                if (AlumnoMateriaExists (alumnosMaterias.AlumnoId, alumnosMaterias.MateriaId)) {
                    return BadRequest ();
                } else {
                    throw;
                }
            }

            return await GetMateriasByAlumno (alumnosMaterias.AlumnoId);
        }

        // POST: AlumMateria/Delete/2
        [HttpDelete]
        public async Task<IActionResult> Delete (int idAlumno, int idMateria) {

            var alumnomateria = await _context.AlumnosMaterias
                .Where (x => x.AlumnoId == idAlumno && x.MateriaId == idMateria)
                .FirstOrDefaultAsync ();
            _context.AlumnosMaterias.Remove (alumnomateria);
            await _context.SaveChangesAsync ();

            return await GetMateriasByAlumno (idAlumno);
        }

        private bool AlumnoMateriaExists (int AlumnoId, int MateriaId) {
            return _context.AlumnosMaterias.Any (e => e.AlumnoId == AlumnoId && e.MateriaId == MateriaId);
        }
    }
}