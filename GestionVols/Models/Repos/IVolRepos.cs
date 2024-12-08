namespace GestionVols.Models.Repos
{
    public interface IVolRepos
    {
        Task<List<Vol>> GetVols();  
        Task<Vol> GetVolByID(int volId); 
        Task<Vol> AddVol(Vol vol);  
        Task UpdateVol(Vol vol); 
        Task DeleteVol(int volId); 
        Task<List<Vol>> GetVolsByAeroportDepart(int aeroportDepartId); 
        Task<List<Vol>> GetVolsByAeroportArrivee(int aeroportArriveeId);  
        Task<List<Vol>> GetVolsByDate(string dateDepart);  

    }
}
