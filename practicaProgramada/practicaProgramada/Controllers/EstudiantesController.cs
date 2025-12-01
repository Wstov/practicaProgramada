using Microsoft.AspNetCore.Mvc;
using PracticaProgramada.BLL.Dtos;
using PracticaProgramada.BLL.Servicios;

namespace PracticaProgramada.Web.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly HttpClient http;

        public EstudiantesController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

        // GET: /Estudiantes
        public async Task<IActionResult> Index()
        {
            var respuesta = await _http.GetFromJsonAsync<ApiRespuesta<List<EstudianteDto>>>("Usuarios");
            var lista = respuesta?.Resultado ?? new List<EstudianteDto>();
            return View(lista);
        }

        // GET: /Estudiantes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var resp = await _http.GetFromJsonAsync<ApiRespuesta<EstudianteDto>>($"Estudiantes/{id}");
            var usuario = resp?.Resultado;
            if (usuario == null) return NotFound();
            return View(usuario);
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
            var resp = await _http.PostAsJson("Estudiante", dto);
            if (!resp.IsSuccesStatusCode) return View(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var estudiante = await _http.GetFromJsonAsync<EstudianteDto>($"Estudiantes/{id}");
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        // POST: /Estudiantes/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(EstudianteDto dto)
        {
            var estudiante = await _http.PutJsonAsync("Estudiante", dto);
            if (!Response.IsSuccessStatusCode) return View(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _http.DeleteAsync("Estudiante/{id}");
            return RedirectToAction(nameof(Index));
        }

        // POST: /Estudiantes/DeleteConfirmed
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _http.DeleteAsync(id);
            if (!result.Ok)
                return BadRequest(result.Mensaje);

            return RedirectToAction(nameof(Index));
        }
    }
}
