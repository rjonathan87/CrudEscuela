using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudEscuela.Models;

namespace ex.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public AlumnoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: obtenermos todos los Alumnos
        public async Task<IActionResult> Index(string searchString)
        {

            var Alumno = _context.Alumnos.AsQueryable();
            
            
            return View(await Alumno.ToListAsync());
        }

    }
}
