using Microsoft.EntityFrameworkCore;

namespace GestionVols.Models.Repos
{
    public class ReservationRepos : IReservationRepos
    {
        private readonly VolDbContext context;

        public ReservationRepos(VolDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Reservation>> GetReservations()
        {
            return await context.Reservations
                .Include(r => r.Passager) 
                .Include(r => r.Vol) 
                .ToListAsync();
        }

        public async Task<Reservation> GetReservationById(int id)   
        {
            return await context.Reservations
                .Include(r => r.Passager)
                .Include(r => r.Vol)
                .FirstOrDefaultAsync(r => r.IdReservation == id);
        }

        public async Task<Reservation> AddReservation(Reservation reservation)
        { 
            var passager = await context.Passagers.FindAsync(reservation.IdPassager);
            var vol = await context.Vols.FindAsync(reservation.IdVol);

            if (passager == null || vol == null)
            {
                throw new ArgumentException("Passager ou Vol non trouvé.");
            } 
            reservation.Passager = passager;
            reservation.Vol = vol;
            reservation.PrixReservationTotal = CalculPrixReservationTotal(vol.PrixVol, reservation.TypeClasse, reservation.NbrePassagers);

            context.Reservations.Add(reservation);
            await context.SaveChangesAsync();

            return reservation;
        }
        public decimal CalculPrixReservationTotal(decimal prixVolBrut, string classType, int nbPassagers)
        {
             decimal multi= classType == "Business" ? 2.0m :
                                 classType == "Economy" ? 1m : 1.5m;
             
            return prixVolBrut * multi*nbPassagers;
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            context.Reservations.Update(reservation);
            await context.SaveChangesAsync();
        }

        public async Task DeleteReservation(int id)
        {
            var reservation = await context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                context.Reservations.Remove(reservation);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Reservation>> GetHistoriqueReservationByPassager(int idPassager) {
            return await context.Reservations.Where(r => r.IdPassager == idPassager)
                        .Include(r => r.Passager)
                        .Include(r => r.Vol)
                        .ToListAsync();

        }

    }
}
