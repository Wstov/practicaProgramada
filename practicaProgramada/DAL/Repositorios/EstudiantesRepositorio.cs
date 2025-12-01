using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticaProgramada.DAL.Entidades;

namespace PracticaProgramada.DAL.Repositorios
{
    public class EstudiantesRepositorio : IEstudiantesRepositorio
    {
        private readonly ApiContext _context;
        public EstudiantesRepositorio(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Estudiante>> ListarAsync()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task<Estudiante> ObtenerPorIdAsync(int id)
        {
            var encontrado = _context.Estudiantes.FirstOrDefault(x => x.Id == id);
            return encontrado;
        }

        public async Task<Estudiante> ObtenerPorCarneAsync(string carne)
        {
            var encontrado = _context.Estudiantes.FirstOrDefault(x => x.Carne == carne);
            return encontrado;
        }

        public async Task<bool> AgregarAsync(Estudiante estudiante)
        {
            await _context.Estudiantes.AddAsync(estudiante);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> ActualizarAsync(Estudiante estudiante)
        {
            var existente = _context.Estudiantes.FirstOrDefault(x => x.Id == estudiante.Id);

            existente.Nombre = estudiante.Nombre;
            existente.Apellido = estudiante.Apellido;
            existente.Carne = estudiante.Carne;
            existente.Email = estudiante.Email;
            existente.Telefono = estudiante.Telefono;

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var existente = _context.Estudiantes.FirstOrDefault(x => x.Id == id);
            _context.Estudiantes.Remove(existente);
            var result = await _context.SaveChangesAsync();
            return result >= 0;
        }
    }
}
