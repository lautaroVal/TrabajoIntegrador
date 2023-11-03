using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechServicesApp.Models.DTOs;
using TechServicesApp.Repository;
using TrabajoIntegrador.Models;

namespace TechServicesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioServices _usuarioServices;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioServices usuarioServices, IMapper mapper)
        {
            _usuarioServices = usuarioServices;
            _mapper = mapper;
        }

        // GET : api/usuarios
        [HttpGet]
        public async Task<List<UsuarioDTO>> GetAllUsuarios()
        {
            var usuarios = await _usuarioServices.GetAllUsuarios();
            var usuariosDTO = _mapper.Map<List<UsuarioDTO>>(usuarios);

            return usuariosDTO;
        }

        // GET : api/usuarios/{id}
        [HttpGet("{id}")]
         public async Task<ActionResult<UsuarioDTO>> GetUsuarioById(int id)
         {
             var usuario = await _usuarioServices.GetUsuarioById(id);
             if (usuario == null)
                 return NotFound("Lo siento, pero este usuario no existe.");

             var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
             return Ok(usuarioDTO);
         }

            // POST : api/usuarios
        [HttpPost("register")]
        public async Task<ActionResult> AddUsuario(Usuario usuario)
        {
            var result = await _usuarioServices.AddUsuario(usuario);
            return Ok(result);
        }

        // PUT : api/usuarios/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuario(int id, Usuario request)
        {
            var result = await _usuarioServices.UpdateUsuario(id, request);
            if (result == null)
                return NotFound("Lo siento, pero este usuario no existe.");

            return Ok(result);
        }

        // DELETE : api/usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var result = await _usuarioServices.DeleteUsuario(id);
            if (result == null)
                return NotFound("Lo siento, pero este usuario no existe.");

            return Ok(result);
        }
    }
}


//{
//    "codUsuario": 3,
//  "nombre": "Julio",
//  "dni": 27456891,
//  "tipo": 2,
//  "contraseña": "789456"
//}
