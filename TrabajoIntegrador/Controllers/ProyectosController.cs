using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechServicesApp.Models.DTOs;
using TechServicesApp.Repository;

namespace TechServicesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly IProyectoServices _proyectoServices;
        private readonly IMapper _mapper;

        public ProyectosController(IProyectoServices proyectoServices, IMapper mapper)
        {
            _proyectoServices = proyectoServices;
            _mapper = mapper;
        }

        // GET : api/proyectos
        [Authorize]
        [HttpGet]
        public async Task<List<ProyectoDTO>> GetAllProyectos()
        {
            var proyectos = await _proyectoServices.GetAllProyectos();
            var proyectosDTO = _mapper.Map<List<ProyectoDTO>>(proyectos);

            return proyectosDTO;
        }

        // GET : api/proyectos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProyectoDTO>> GetProyectoById(int id)
        {
            var proyecto = await _proyectoServices.GetProyectoById(id);
            if (proyecto == null)
                return NotFound("Lo siento, pero este proyecto no existe.");

            var proyectoDTO = _mapper.Map<ProyectoDTO>(proyecto);
            return Ok(proyectoDTO);
        }

        // POST : api/proyectos
        [HttpPost]
        public async Task<ActionResult> AddProyectos(Proyecto proyecto)
        {
            var result = await _proyectoServices.AddProyectos(proyecto);
            return Ok(result);
        }

        // PUT : api/proyectos/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProyecto(int id, Proyecto request)
        {
            var result = await _proyectoServices.UpdateProyecto(id, request);
            if (result == null)
                return NotFound("Lo siento, pero este proyecto no existe.");

            return Ok(result);
        }

        // DELETE : api/proyectos/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProyecto(int id)
        {
            var result = await _proyectoServices.DeleteProyecto(id);
            if (result == null)
                return NotFound("Lo siento, pero este proyecto no existe.");

            return Ok(result);
        }
    }
}

