using AutoMapper;
using PracticaProgramada.BLL.Dtos;
using PracticaProgramada.DAL.Entidades;

namespace PracticaProgramada.BLL.Mapeos
{
    public class MapeoClases : Profile
    {
        public MapeoClases()
        {
            CreateMap<Estudiante, EstudianteDto>();
        }
    }
}
