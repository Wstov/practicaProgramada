using PracticaProgramada.BLL.Dtos;

namespace PracticaProgramada.Web.Services
{
    public interface IApiClient
    {
        Task<List<EstudianteDto>> ListarEstudiantesAsync();
        Task<EstudianteDto> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(EstudianteDto dto);
        Task<bool> ActualizarAsync(EstudianteDto dto);
        Task<bool> EliminarAsync(int id);
    }
}
