﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionVols.Models.Repos
{
    public class VolRepos : IVolRepos
    {
        private readonly VolDbContext context;

        public VolRepos(VolDbContext context)
        {
            this.context = context;
        }
        public async Task<Vol> AddVol(Vol vol)
        {
            try
            {
                var result = await context.Vols.AddAsync(vol);
                await context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding Aeroport: {ex.Message}");
                throw;
            }
           
        }

        public async Task DeleteVol(int volId)
        {
            var vol = await context.Vols.FindAsync(volId);
            if (vol != null)
            {
                context.Vols.Remove(vol);
                await context.SaveChangesAsync();
            }
        }

         
       
        public async Task<Vol> GetVolByID(int volId)
        {
            return await context.Vols
                 .Include(v => v.AeroportDepart)
                 .Include(v => v.AeroportArrivee)
                 .FirstOrDefaultAsync(v => v.IdVol == volId);
        }

        public async Task<List<Vol>> GetVols()
        {
            return await context.Vols
                .Include(v => v.AeroportDepart) 
               .Include(v => v.AeroportArrivee) 
                .ToListAsync();
        }

        public async Task<List<Vol>> GetVolsByAeroportArrivee(int aeroportArriveeId)
        {
            return await context.Vols
               .Where(v => v.IdAeroportArrivee == aeroportArriveeId)
               .ToListAsync();
        }

        public async Task<List<Vol>> GetVolsByAeroportDepart(int aeroportDepartId)
        {
            return await context.Vols
                   .Where(v => v.IdAeroportDepart == aeroportDepartId)
                   .ToListAsync();
        }

        public Task<List<Vol>> GetVolsByDate(string dateDepart)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Vol>> GetVolsByDate(string dateDepart)
        //{
        //    return await context.Vols
        //       .Where(v => v.HeureDepart == dateDepart)
        //       .ToListAsync();
        //}

        public async Task UpdateVol(Vol vol)
        {
            context.Vols.Update(vol);
            await context.SaveChangesAsync();
        }

        public async Task<List<Vol>> RechercheVol(RechercheVolRequest request)
        {
            var query = context.Vols
                .Include(v => v.AeroportDepart)  
                .Include(v => v.AeroportArrivee)
                .Include(v => v.Avion)
                .AsQueryable();

       
            if (!string.IsNullOrEmpty(request.Depart))
            {
                query = query.Where(v => v.AeroportDepart.NomAeroport.Contains(request.Depart));
            }

 
            if (!string.IsNullOrEmpty(request.Destination))
            {
                query = query.Where(v => v.AeroportArrivee.NomAeroport.Contains(request.Destination));
            }

             if (request.DateDepart.HasValue)
            {
                query = query.Where(v => v.HeureDepart.Date == request.DateDepart.Value.Date);
            }

             if (request.DateRetour.HasValue)
            {
                query = query.Where(v => v.HeureArrivee.Date == request.DateRetour.Value.Date);
            }

             if (request.NbreVoyageurs.HasValue)
            {
                query = query.Where(v => v.PlacesDisponibles >= request.NbreVoyageurs.Value);
            }
             
            if (!string.IsNullOrEmpty(request.ClassVol))
            {
                query = query.Where(v => v.TypeAvion.Equals(request.ClassVol, StringComparison.OrdinalIgnoreCase));
            }
             
            var flights = await query.ToListAsync();
            return flights;
        }

        public async Task<Offre> AddOffre(Offre offre)
        {
            var result = await context.Offres.AddAsync(offre);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Offre>> GetOffres()
        {
            return await context.Offres.ToListAsync();
        }

        public async Task<List<Offre>> GetOffresPourVol(int volId)
        {
            return await context.Offres
                .Where(o => o.IdVol == volId)
                .ToListAsync();
        }



    }
}
