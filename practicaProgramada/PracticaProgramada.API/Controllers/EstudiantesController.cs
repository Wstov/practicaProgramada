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
        [HttpGet(Name = "ListarEstudiantes")]
        public async Task<IActionResult> Index()
        {
            var lista = await _servicio.ListarAsync();
            return View(lista);
        }

        // POST: /Estudiantes/Create
        [HttpGet(Name = "CrearEstudiante")]
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
        [HttpGet(Name = "ListarEstudiante")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _servicio.ObtenerPorIdAsync(id);
            if (!result.Ok) return NotFound();

            return View(result.Datos);
        }

        // GET: /Estudiantes/Delete/5
        [HttpDelete("{id}", Name = "EliminarEstudiante")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _servicio.ObtenerPorIdAsync(id);
            if (!result.Ok) return NotFound();

            return View(result.Datos);
        }

        // POST: /Estudiantes/Edit
        [HttpPut(Name = "EditarEstudiantes")]
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
    }
}
