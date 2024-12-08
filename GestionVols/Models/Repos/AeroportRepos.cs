using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GestionVols.Models.Repos
{
    public class AeroportRepos : IAeroportRepos
    {
        private readonly VolDbContext context;

        public AeroportRepos(VolDbContext context)
        {
            this.context = context;
        }
        public async  Task<List<Aeroport>> GetAeroports(){
            return await context.Aeroports.ToListAsync();
        }
        public async Task<Aeroport> GetAeroportByID(int aeroportid){
    
            Aeroport aero = await context.Aeroports.FindAsync(aeroportid);
            return aero;
        }
       
        public async Task<Aeroport> AddAeroport(Aeroport aeroport)
        {
            try
            {
                var result = await context.Aeroports.AddAsync(aeroport);
                await context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Error adding Aeroport: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAeroport(Aeroport aeroport) { 
            context.Aeroports.Update(aeroport);
            await context.SaveChangesAsync();
        }
        public async Task  DeleteAeroport(int aeroportid){
            var aero = await context.Aeroports.FindAsync(aeroportid);
            context.Aeroports.Remove(aero);
            await context.SaveChangesAsync();
        }
    }
}
