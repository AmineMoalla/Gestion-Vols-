﻿using Microsoft.EntityFrameworkCore;

namespace GestionVols.Models
{
    public class VolDbContext : DbContext
    {
        public VolDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Vol> Vols { get; set; }
        public DbSet<Passager> Passagers { get; set; }
        public DbSet<Aeroport> Aeroports { get; set; }
        public DbSet<Avion> Avions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vol>()
                .HasOne(v => v.AeroportDepart)
                .WithMany()
                .HasForeignKey(v => v.IdAeroportDepart)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Vol>()
                .HasOne(v => v.AeroportArrivee)
                .WithMany()
                .HasForeignKey(v => v.IdAeroportArrivee)
                .OnDelete(DeleteBehavior.Restrict); 
        }



    }
}
