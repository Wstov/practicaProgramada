using System.Collections.Generic;
using System.Threading.Tasks;
using PracticaProgramada.DAL.Entidades;

namespace PracticaProgramada.DAL.Repositorios
{
    public interface IEstudiantesRepositorio
    {
        Task<List<Estudiante>> ListarAsync();
        Task<Estudiante> ObtenerPorIdAsync(int id);
        Task<Estudiante> ObtenerPorCarneAsync(string carne);
        Task<bool> AgregarAsync(Estudiante estudiante);
        Task<bool> ActualizarAsync(Estudiante estudiante);
        Task<bool> EliminarAsync(int id);
    }
}
