using ApiReservaTurnos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiReservaTurnos.Persistencia.Context
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Comercio> Comercio { get; set; }     
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Turnos> Turnos { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>()
            .HasKey(ur => new { ur.id_Servicio});//LLave Primaria

            modelBuilder.Entity<Servicio>()
                .HasOne(ur => ur.Comercio)
                .WithMany(u => u.Servicio)
                .HasForeignKey(ur => ur.id_Comercio);// 1 comercio tiene muchos servicios

            modelBuilder.Entity<Turnos>()
             .HasKey(ur => new { ur.id_turno });//LLave Primaria

            modelBuilder.Entity<Turnos>()
                .HasOne(ur => ur.Servicio)// uno a uno
                .WithMany(u => u.Turnos)
                .HasForeignKey(ur => ur.id_servicio);

        }
    }
}
