using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechServicesApp.Repository
{
    public class ProyectoServices : IProyectoServices
    {

        private readonly TechServicesAppDbContext _context;

        public ProyectoServices(TechServicesAppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Proyecto>> AddProyectos(Proyecto proyecto)
        {
            _context.Proyectos.Add(proyecto);
            await _context.SaveChangesAsync();
            return await _context.Proyectos.ToListAsync();
        }

        public async Task<List<Proyecto>> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
                return null;

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();
            return await _context.Proyectos.ToListAsync();
        }

        public async Task<List<Proyecto>> GetAllProyectos()
        {
            var proyectos = await _context.Proyectos.ToListAsync();
            return proyectos;
        }

        public async Task<Proyecto> GetProyectoById(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
                return null;

            return proyecto;
        }

        public async Task<List<Proyecto>> UpdateProyecto(int id, Proyecto request)
    {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
                return null;

            proyecto.Nombre = request.Nombre;
            proyecto.Direccion = request.Direccion;
            proyecto.Estado = request.Estado;

            await _context.SaveChangesAsync();

            return await _context.Proyectos.ToListAsync();
        }

    }
}
