using PracticaProgramada.BLL.Dtos;

namespace PracticaProgramada.BLL.Servicios
{
    public interface IEstudiantesServicio
    {
        Task<List<EstudianteDto>> ListarAsync();
        Task<CustomResponse<EstudianteDto>> ObtenerPorIdAsync(int id);
        Task<CustomResponse<EstudianteDto>> CrearAsync(EstudianteDto dto);
        Task<CustomResponse<EstudianteDto>> ActualizarAsync(EstudianteDto dto);
        Task<CustomResponse<bool>> EliminarAsync(int id);
    }
}
