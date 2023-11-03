using Microsoft.EntityFrameworkCore;
using TrabajoIntegrador.Models;

namespace TechServicesApp.Repository
{
    public class TrabajoServices : ITrabajoServices
    {

        private readonly TechServicesAppDbContext _context;

        public TrabajoServices(TechServicesAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trabajo>> AddTrabajos(Trabajo trabajo)
        {
            _context.Trabajos.Add(trabajo);
            await _context.SaveChangesAsync();
            return await _context.Trabajos.ToListAsync();
        }

        public async Task<List<Trabajo>> DeleteTrabajo(int id)
        {
            var trabajo = await _context.Trabajos.FindAsync(id);
            if (trabajo == null)
                return null;

            _context.Trabajos.Remove(trabajo);
            await _context.SaveChangesAsync();
            return await _context.Trabajos.ToListAsync();
        }

        public async Task<List<Trabajo>> GetAllTrabajos()
        {
            var trabajos = await _context.Trabajos.ToListAsync();
            return trabajos;
        }

        public async Task<Trabajo> GetTrabajoById(int id)
        {
            var trabajo = await _context.Trabajos.FindAsync(id);
            if (trabajo == null)
                return null;

            return trabajo;
        }

        public async Task<List<Trabajo>> UpdateTrabajo(int id, Trabajo request)
        {
            var trabajo = await _context.Trabajos.FindAsync(id);
            if (trabajo == null)
                return null;

            trabajo.Fecha = request.Fecha;
            trabajo.CodProyecto = request.CodProyecto;
            trabajo.CodServicio = request.CodServicio;
            trabajo.CantHoras = request.CantHoras;
            trabajo.ValorHora = request.ValorHora;
            trabajo.Costo = request.Costo;

            await _context.SaveChangesAsync();

            return await _context.Trabajos.ToListAsync();
        }
    }
}
