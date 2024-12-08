using Microsoft.EntityFrameworkCore;

namespace GestionVols.Models.Repos
{
    public class PassagerRepos : IPassagerRepos
    {
        private readonly VolDbContext context;

        public PassagerRepos(VolDbContext context)
        {
            this.context = context;
        }
        
        public async Task<List<Passager>> GetPassagers()
        {
            return await context.Passagers.ToListAsync();
        }

        public async Task<Passager> GetPassagerById(int id)
        {
            return await context.Passagers.FindAsync(id);
        }

        public async Task<Passager> AddPassager(Passager passager)
        {
            var result = await context.Passagers.AddAsync(passager);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdatePassager(Passager passager)
        {
            context.Passagers.Update(passager);
            await context.SaveChangesAsync();
        }

        public async Task DeletePassager(int id)
        {
            var passager = await context.Passagers.FindAsync(id);
            if (passager != null)
            {
                context.Passagers.Remove(passager);
                await context.SaveChangesAsync();
            }
        }
    }
}
