using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaProgramada.DAL.Entidades;

namespace PracticaProgramada.DAL.Repositorios
{
    public class EstudiantesRepositorio : IEstudiantesRepositorio
    {
        private readonly List<Estudiante> _tabla = new List<Estudiante>();

        public Task<List<Estudiante>> ListarAsync()
        {
            return Task.FromResult(_tabla);
        }

        public Task<Estudiante> ObtenerPorIdAsync(int id)
        {
            var encontrado = _tabla.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(encontrado);
        }

        public Task<Estudiante> ObtenerPorCarneAsync(string carne)
        {
            var encontrado = _tabla.FirstOrDefault(x => x.Carne == carne);
            return Task.FromResult(encontrado);
        }

        public Task<bool> AgregarAsync(Estudiante estudiante)
        {
            estudiante.Id = _tabla.Any() ? _tabla.Max(x => x.Id) + 1 : 1;
            _tabla.Add(estudiante);
            return Task.FromResult(true);
        }

        public Task<bool> ActualizarAsync(Estudiante estudiante)
        {
            var existente = _tabla.FirstOrDefault(x => x.Id == estudiante.Id);
            if (existente == null) return Task.FromResult(false);

            existente.Nombre = estudiante.Nombre;
            existente.Apellido = estudiante.Apellido;
            existente.Carne = estudiante.Carne;
            existente.Email = estudiante.Email;
            existente.Telefono = estudiante.Telefono;

            return Task.FromResult(true);
        }

        public Task<bool> EliminarAsync(int id)
        {
            var existente = _tabla.FirstOrDefault(x => x.Id == id);
            if (existente == null) return Task.FromResult(false);

            _tabla.Remove(existente);
            return Task.FromResult(true);
        }
    }
}
