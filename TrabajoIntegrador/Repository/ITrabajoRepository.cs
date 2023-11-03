namespace TechServicesApp.Repository
{
    public interface ITrabajoServices
    {
        Task<List<Trabajo>> GetAllTrabajos();
        Task<Trabajo> GetTrabajoById(int id);
        Task<List<Trabajo>> AddTrabajos(Trabajo trabajo);
        Task<List<Trabajo>> UpdateTrabajo(int id, Trabajo request);
        Task<List<Trabajo>> DeleteTrabajo(int id);
    }
}
