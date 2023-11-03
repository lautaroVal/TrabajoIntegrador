namespace TechServicesApp.Repository
{
    public interface IServicioServices
    {
        Task<List<Servicio>> GetAllServicios();
        Task<Servicio> GetServicioById(int id);
        Task<List<Servicio>> AddServicio(Servicio servicio);
        Task<List<Servicio>> UpdateServicio(int id, Servicio request);
        Task<List<Servicio>> DeleteServicio(int id);
    }
}
