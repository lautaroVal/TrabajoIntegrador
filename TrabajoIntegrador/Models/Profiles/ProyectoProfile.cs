using AutoMapper;
using TechServicesApp.Models.DTOs;

namespace TechServicesApp.Models.Profiles
{
    public class ProyectoProfile : Profile
    {
        public ProyectoProfile() 
        {
            CreateMap<Proyecto, ProyectoDTO>();
        }
    }
}
