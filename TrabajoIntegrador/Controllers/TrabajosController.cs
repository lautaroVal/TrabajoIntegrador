using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechServicesApp.Models.DTOs;
using TechServicesApp.Repository;
using TrabajoIntegrador.Models;

namespace TechServicesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajosController : ControllerBase
    {

        private readonly ITrabajoServices _trabajoServices;
        private readonly IMapper _mapper;

        public TrabajosController(ITrabajoServices trabajoServices, IMapper mapper)
        {
            _trabajoServices = trabajoServices;
            _mapper = mapper;
        }

        // GET : api/trabajos
        [HttpGet]
        public async Task<List<TrabajoDTO>> GetAllTrabajos()
        { 
            var trabajos = await _trabajoServices.GetAllTrabajos();
            var trabajosDTO = _mapper.Map<List<TrabajoDTO>>(trabajos);

            return trabajosDTO;
        }

        // GET : api/trabajos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TrabajoDTO>> GetTrabajoById(int id)
        {
            var trabajo = await _trabajoServices.GetTrabajoById(id);
            if (trabajo == null)
                return NotFound("Lo siento, pero este trabajo no existe.");

            var trabajoDTO = _mapper.Map<TrabajoDTO>(trabajo);
            return Ok(trabajoDTO);
        }

        // POST : api/trabajos
        [HttpPost]
        public async Task<ActionResult> AddTrabajos(Trabajo trabajo)
        {
            var result = await _trabajoServices.AddTrabajos(trabajo);
            return Ok(result);
        }

        // PUT : api/trabajos/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTrabajo(int id, Trabajo request)
        {
            var result = await _trabajoServices.UpdateTrabajo(id, request);
            if (result == null)
                return NotFound("Lo siento, pero este trabajo no existe.");

            return Ok(result);
        }

        // DELETE : api/trabajos/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTrabajo(int id)
        {
            var result = await _trabajoServices.DeleteTrabajo(id);
            if (result == null)
                return NotFound("Lo siento, pero este trabajo no existe.");

            return Ok(result);
        }
    }
}
