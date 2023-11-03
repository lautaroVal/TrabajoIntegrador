using AutoMapper;
using TechServicesApp.Models.DTOs;

namespace TechServicesApp.Models.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
