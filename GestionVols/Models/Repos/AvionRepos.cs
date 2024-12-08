using Microsoft.EntityFrameworkCore;

namespace GestionVols.Models.Repos
{
    public class AvionRepos :IAvionRepos
    {
        private readonly VolDbContext context;

        public AvionRepos(VolDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Avion>> GetAvions()
        {
            return await context.Avions.ToListAsync();
        }

        public async Task<Avion> GetAvionByID(int idAvion)
        {
            return await context.Avions.FirstOrDefaultAsync(a => a.IdAvion == idAvion);
        }

        public async Task<Avion> AddAvion(Avion avion)
        {
            var result = await context.Avions.AddAsync(avion);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAvion(Avion avion)
        {
            context.Avions.Update(avion);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAvion(int idAvion)
        {
            var avion = await context.Avions.FindAsync(idAvion);
            if (avion != null)
            {
                context.Avions.Remove(avion);
                await context.SaveChangesAsync();
            }
        }
    }
}
