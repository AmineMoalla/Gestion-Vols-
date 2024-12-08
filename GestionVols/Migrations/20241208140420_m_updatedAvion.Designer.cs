﻿// <auto-generated />
using System;
using GestionVols.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionVols.Migrations
{
    [DbContext(typeof(VolDbContext))]
    [Migration("20241208140420_m_updatedAvion")]
    partial class m_updatedAvion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionVols.Models.Aeroport", b =>
                {
                    b.Property<int>("IdAeroport")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAeroport"));

                    b.Property<string>("NomAeroport")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaysAeroport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VilleAeroport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAeroport");

                    b.ToTable("Aeroports");
                });

            modelBuilder.Entity("GestionVols.Models.Avion", b =>
                {
                    b.Property<int>("IdAvion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAvion"));

                    b.Property<int>("CapaciteAvion")
                        .HasColumnType("int");

                    b.Property<string>("FabriquantAvion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeAvion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAvion");

                    b.ToTable("Avions");
                });

            modelBuilder.Entity("GestionVols.Models.Passager", b =>
                {
                    b.Property<int>("IdPassager")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPassager"));

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailPassager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomPassager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroPasseport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrenomPassager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephonePassager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPassager");

                    b.ToTable("Passagers");
                });

            modelBuilder.Entity("GestionVols.Models.Vol", b =>
                {
                    b.Property<int>("IdVol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVol"));

                    b.Property<DateTime>("HeureArrivee")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HeureDepart")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAeroportArrivee")
                        .HasColumnType("int");

                    b.Property<int>("IdAeroportDepart")
                        .HasColumnType("int");

                    b.Property<string>("NumeroVol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Porte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeAvion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVol");

                    b.HasIndex("IdAeroportArrivee");

                    b.HasIndex("IdAeroportDepart");

                    b.ToTable("Vols");
                });

            modelBuilder.Entity("GestionVols.Models.Vol", b =>
                {
                    b.HasOne("GestionVols.Models.Aeroport", "AeroportArrivee")
                        .WithMany()
                        .HasForeignKey("IdAeroportArrivee")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestionVols.Models.Aeroport", "AeroportDepart")
                        .WithMany()
                        .HasForeignKey("IdAeroportDepart")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AeroportArrivee");

                    b.Navigation("AeroportDepart");
                });
#pragma warning restore 612, 618
        }
    }
}
