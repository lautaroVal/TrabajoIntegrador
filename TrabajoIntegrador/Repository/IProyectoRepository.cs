using Microsoft.AspNetCore.Mvc;

namespace TechServicesApp.Repository
{
    public interface IProyectoServices
    {
        Task<List<Proyecto>> GetAllProyectos();
        Task<Proyecto> GetProyectoById(int id);
        Task<List<Proyecto>> AddProyectos(Proyecto proyecto);
        Task<List<Proyecto>> UpdateProyecto(int id, Proyecto request);
        Task<List<Proyecto>> DeleteProyecto(int id);

    }
}
