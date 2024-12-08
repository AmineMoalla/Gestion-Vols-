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
            // Vérifiez si les entités liées existent
            var passager = await context.Passagers.FindAsync(reservation.IdPassager);
            var vol = await context.Vols.FindAsync(reservation.IdVol);

            if (passager == null || vol == null)
            {
                throw new ArgumentException("Passager ou Vol non trouvé.");
            }

            // Associez les entités
            reservation.Passager = passager;
            reservation.Vol = vol;

            context.Reservations.Add(reservation);
            await context.SaveChangesAsync();

            return reservation;
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

    }
}
