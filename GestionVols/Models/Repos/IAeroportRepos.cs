namespace GestionVols.Models.Repos
{
    public interface IAeroportRepos
    {
        Task<List<Aeroport>> GetAeroports();
        Task<Aeroport> GetAeroportByID(int aeroportid);
        Task<Aeroport> AddAeroport(Aeroport aeroport);
        Task  UpdateAeroport(Aeroport aeroport);
        Task DeleteAeroport(int aeroportid);  
     }
}
