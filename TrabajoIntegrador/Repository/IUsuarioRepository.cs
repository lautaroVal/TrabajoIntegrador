namespace TechServicesApp.Repository
{
    public interface IUsuarioServices
    {
        Task<List<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<List<Usuario>> AddUsuario(Usuario usuario);
        Task<List<Usuario>> UpdateUsuario(int id, Usuario request);
        Task<List<Usuario>> DeleteUsuario(int id);
    }
}
