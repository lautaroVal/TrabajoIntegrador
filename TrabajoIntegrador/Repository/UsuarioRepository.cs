using Microsoft.EntityFrameworkCore;
using TrabajoIntegrador.Models;

namespace TechServicesApp.Repository
{
    public class UsuarioServices : IUsuarioServices
    {

        private readonly TechServicesAppDbContext _context;

        public UsuarioServices(TechServicesAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<List<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return null;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return null;

            return usuario;
        }

        public async Task<List<Usuario>> UpdateUsuario(int id, Usuario request)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return null;

            usuario.Nombre = request.Nombre;
            usuario.Dni = request.Dni;
            usuario.Tipo = request.Tipo;
            usuario.Contraseña = request.Contraseña;

            await _context.SaveChangesAsync();

            return await _context.Usuarios.ToListAsync();
        }
    }
}
