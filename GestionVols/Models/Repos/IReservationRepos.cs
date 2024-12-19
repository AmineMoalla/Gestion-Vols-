using Microsoft.AspNetCore.Mvc;

namespace GestionVols.Models.Repos
{
    public interface IReservationRepos
    {
        Task<List<Reservation>> GetReservations();  
        Task<Reservation> GetReservationById(int id); 
        Task<Reservation> AddReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);  
        Task DeleteReservation(int id);
        //Task<List<Reservation>> GetHistoriqueReservationByPassager(int passagerId);
        Task<List<Reservation>> GetHistoriqueReservationByEmail(string email);
    }
}
