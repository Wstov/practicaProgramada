using Microsoft.AspNetCore.Mvc;
using PracticaProgramada.BLL.Dtos;
using PracticaProgramada.BLL.Servicios;

namespace PracticaProgramada.Web.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly IEstudiantesServicio _servicio;

        public EstudiantesController(IEstudiantesServicio servicio)
        {
            _servicio = servicio;
        }

        // GET: /Estudiantes
        public async Task<IActionResult> Index()
        {
            var lista = await _servicio.ListarAsync();
            return View(lista);
        }

        // GET: /Estudiantes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _servicio.ObtenerPorIdAsync(id);
            if (!result.Ok) return NotFound();

            return View(result.Datos);
        }

        // GET: /Estudiantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Estudiantes/Create
        [HttpPost]
        public async Task<IActionResult> Create(EstudianteDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _servicio.CrearAsync(dto);
            if (!result.Ok)
            {
                ModelState.AddModelError("", result.Mensaje);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _servicio.ObtenerPorIdAsync(id);
            if (!result.Ok) return NotFound();

            return View(result.Datos);
        }

        // POST: /Estudiantes/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(EstudianteDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _servicio.ActualizarAsync(dto);
            if (!result.Ok)
            {
                ModelState.AddModelError("", result.Mensaje);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _servicio.ObtenerPorIdAsync(id);
            if (!result.Ok) return NotFound();

            return View(result.Datos);
        }

        // POST: /Estudiantes/DeleteConfirmed
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _servicio.EliminarAsync(id);
            if (!result.Ok)
                return BadRequest(result.Mensaje);

            return RedirectToAction(nameof(Index));
        }
    }
}
