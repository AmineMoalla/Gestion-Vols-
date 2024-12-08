namespace GestionVols.Models.Repos
{
    public interface IAvionRepos
    {
        Task<List<Avion>> GetAvions(); 
        Task<Avion> GetAvionByID(int idAvion);  
        Task<Avion> AddAvion(Avion avion); 
        Task UpdateAvion(Avion avion);  
        Task DeleteAvion(int idAvion);
    }
}
