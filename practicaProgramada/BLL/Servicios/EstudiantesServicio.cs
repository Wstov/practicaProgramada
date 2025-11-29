using AutoMapper;
using PracticaProgramada.BLL.Dtos;
using PracticaProgramada.DAL.Entidades;
using PracticaProgramada.DAL.Repositorios;

namespace PracticaProgramada.BLL.Servicios
{
    public class EstudiantesServicio : IEstudiantesServicio
    {
        private readonly IEstudiantesRepositorio _repo;
        private readonly IMapper _mapper;

        public EstudiantesServicio(IEstudiantesRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<EstudianteDto>> ListarAsync()
        {
            var lista = await _repo.ListarAsync();
            return _mapper.Map<List<EstudianteDto>>(lista);
        }

        public async Task<CustomResponse<EstudianteDto>> ObtenerPorIdAsync(int id)
        {
            var entidad = await _repo.ObtenerPorIdAsync(id);
            if (entidad == null)
                return CustomResponse<EstudianteDto>.Fail("Estudiante no encontrado");

            var dto = _mapper.Map<EstudianteDto>(entidad);
            return CustomResponse<EstudianteDto>.Success(dto);
        }

        public async Task<CustomResponse<EstudianteDto>> CrearAsync(EstudianteDto dto)
        {
            // Validación del carné único
            var existe = await _repo.ObtenerPorCarneAsync(dto.Carne);
            if (existe != null)
                return CustomResponse<EstudianteDto>.Fail("El carné ya existe");

            var entidad = _mapper.Map<Estudiante>(dto);

            var ok = await _repo.AgregarAsync(entidad);
            if (!ok)
                return CustomResponse<EstudianteDto>.Fail("Error al guardar");

            // Se actualiza el Id en el DTO
            dto.Id = entidad.Id;

            return CustomResponse<EstudianteDto>.Success(dto, "Estudiante registrado");
        }

        public async Task<CustomResponse<EstudianteDto>> ActualizarAsync(EstudianteDto dto)
        {
            var entidad = _mapper.Map<Estudiante>(dto);

            var ok = await _repo.ActualizarAsync(entidad);
            if (!ok)
                return CustomResponse<EstudianteDto>.Fail("Error al actualizar");

            return CustomResponse<EstudianteDto>.Success(dto, "Estudiante actualizado");
        }

        public async Task<CustomResponse<bool>> EliminarAsync(int id)
        {
            var ok = await _repo.EliminarAsync(id);
            if (!ok)
                return CustomResponse<bool>.Fail("No se pudo eliminar");

            return CustomResponse<bool>.Success(true, "Estudiante eliminado");
        }
    }
}
