using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEscuela.Models;

namespace CrudEscuela.Controllers
{
    public class MateriaController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public MateriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: obtenermos todas las materias
        public async Task<IActionResult> Index()
        {
            var materias = _context.Materias.AsQueryable();
            
            
            return View(await materias.ToListAsync());
        }

        // GET vista para crear Materias 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreMateria, Activo, Costo")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }

        // GET: Materia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            return View(materia);
        }

        // POST: Materia/Edit/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreMateria,Activo,Costo")] Materia materia)
        {
            if (id != materia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }

        // GET: Materia/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: Materia/Delete/4
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool MateriaExists(int id)
        {
            return _context.Materias.Any(e => e.Id == id);
        }

        // retorna una lista de codigos según la búsqueda que llega
        [HttpPost]
        public async Task<JsonResult> MateriasDisponibles(string search)
        {
            var MateriasList = await _context.Materias
                .Where(m => m.NombreMateria.Contains(search))
                .Select(s => new { 
                                    Id              = s.Id,
                                    NombreMateria   = s.NombreMateria,
                                    Activo          = s.Activo,
                                    Costo           = s.Costo
                                })
                .ToListAsync();
                            
            return Json(MateriasList);
        }

    }
}
