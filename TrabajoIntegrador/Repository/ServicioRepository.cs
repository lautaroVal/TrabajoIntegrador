using Microsoft.EntityFrameworkCore;
using TrabajoIntegrador.Models;

namespace TechServicesApp.Repository
{
    public class ServicioServices : IServicioServices
    {

        private readonly TechServicesAppDbContext _context;

        public ServicioServices(TechServicesAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> AddServicio(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return await _context.Servicios.ToListAsync();
        }

        public async Task<List<Servicio>> DeleteServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
                return null;

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
            return await _context.Servicios.ToListAsync();
        }

        public async Task<List<Servicio>> GetAllServicios()
        {
            var servicios = await _context.Servicios.ToListAsync();
            return servicios;
        }

        public async Task<Servicio> GetServicioById(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
                return null;

            return servicio;
        }

        public async Task<List<Servicio>> UpdateServicio(int id, Servicio request)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
                return null;

            servicio.Descr = request.Descr;
            servicio.Estado = request.Estado;
            servicio.ValorHora = request.ValorHora;

            await _context.SaveChangesAsync();

            return await _context.Servicios.ToListAsync();
        }
    }
}
