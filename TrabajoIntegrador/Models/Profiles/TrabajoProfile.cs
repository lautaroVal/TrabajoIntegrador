using AutoMapper;
using TechServicesApp.Models.DTOs;

namespace TechServicesApp.Models.Profiles
{
    public class TrabajoProfile : Profile
    {
        public TrabajoProfile()
        {
            CreateMap<Trabajo, TrabajoDTO>();
        }
    }
}
