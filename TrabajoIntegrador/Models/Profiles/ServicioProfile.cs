using AutoMapper;
using TechServicesApp.Models.DTOs;

namespace TechServicesApp.Models.Profiles
{
    public class ServicioProfile : Profile
    {
        public ServicioProfile()
        {
            CreateMap<Servicio, ServicioDTO>();
        }
    }
}
