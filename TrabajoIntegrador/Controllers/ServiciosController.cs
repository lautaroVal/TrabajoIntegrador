using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechServicesApp.Models.DTOs;
using TechServicesApp.Repository;
using TrabajoIntegrador.Models;

namespace TechServicesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioServices _servicioServices;
        private readonly IMapper _mapper;

        public ServiciosController(IServicioServices servicioServices, IMapper mapper)
        {
            _servicioServices = servicioServices;
            _mapper = mapper;
        }

        // GET : api/servicios
        [HttpGet]
        public async Task<List<ServicioDTO>> GetAllServicios()
        {
            var servicios = await _servicioServices.GetAllServicios();
            var serviciosDTO = _mapper.Map<List<ServicioDTO>>(servicios);

            return serviciosDTO;
        }

        // GET : api/servicios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioDTO>> GetServicioById(int id)
        {
            var servicio = await _servicioServices.GetServicioById(id);
            if (servicio == null)
                return NotFound("Lo siento, pero este servicio no existe.");

            var servicioDTO = _mapper.Map<ServicioDTO>(servicio);
            return Ok(servicioDTO);
        }

        // POST : api/servicios
        [HttpPost]
        public async Task<ActionResult> AddServicio(Servicio servicio)
        {
            var result = await _servicioServices.AddServicio(servicio);
            return Ok(result);
        }

        // PUT : api/servicios/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateServicio(int id, Servicio request)
        {
            var result = await _servicioServices.UpdateServicio(id, request);
            if (result == null)
                return NotFound("Lo siento, pero este servicio no existe.");

            return Ok(result);
        }

        // DELETE : api/servicios/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServicio(int id)
        {
            var result = await _servicioServices.DeleteServicio(id);
            if (result == null)
                return NotFound("Lo siento, pero este proyecto no existe.");

            return Ok(result);
        }
    }
}
