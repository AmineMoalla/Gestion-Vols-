namespace GestionVols.Models.Repos
{
    public interface IPassagerRepos
    {
        Task<List<Passager>> GetPassagers();
        Task<Passager> GetPassagerById(int id);  
        Task<Passager> AddPassager(Passager passager); 
        Task UpdatePassager(Passager passager);  
        Task DeletePassager(int id); 
    }
}
