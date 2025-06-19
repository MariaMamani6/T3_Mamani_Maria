using Microsoft.AspNetCore.Mvc;
using T3_Mamani_Maria.Datos;
using T3_Mamani_Maria.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace T3_Mamani_Maria.Controllers
{
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Libro - Mostrar lista y formulario vacío para crear
        public async Task<IActionResult> Index(int? id)
        {
            Libro libro;
            if (id == null)
            {
                libro = new Libro(); // Nuevo libro (crear)
            }
            else
            {
                libro = await _context.Libro.FindAsync(id); // Editar libro
                if (libro == null) return NotFound();
            }

            var listaLibros = await _context.Libro.ToListAsync();

            // Enviar ambos a la vista usando ViewModel simple con ViewData
            ViewData["ListaLibros"] = listaLibros;
            return View(libro);
        }

        // POST: Guardar (crear o editar)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ListaLibros"] = await _context.Libro.ToListAsync();
                return View(libro);
            }

            if (libro.Id == 0)
            {
                _context.Add(libro);
            }
            else
            {
                _context.Update(libro);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var libro = await _context.Libro.FindAsync(id);
            if (libro != null)
            {
                _context.Libro.Remove(libro);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
