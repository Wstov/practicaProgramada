using PracticaProgramada.BLL.Dtos;

namespace PracticaProgramada.Web.Services
{
    public class ApiClient : IApiClient
    {
        public Task<List<EstudianteDto>> ListarEstudiantesAsync()
        {
            return Task.FromResult(new List<EstudianteDto>());
        }

        public Task<EstudianteDto> ObtenerPorIdAsync(int id)
        {
            return Task.FromResult<EstudianteDto>(null);
        }

        public Task<bool> CrearAsync(EstudianteDto dto)
        {
            return Task.FromResult(false);
        }

        public Task<bool> ActualizarAsync(EstudianteDto dto)
        {
            return Task.FromResult(false);
        }

        public Task<bool> EliminarAsync(int id)
        {
            return Task.FromResult(false);
        }
    }
}
