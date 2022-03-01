using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaMigracion.ViewModels;

namespace PracticaMigracion.Models
{
	public class DatabaseContext : DbContext
    {
        // public PracticaContexto() : base("PracticaMigracion") { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-JOBSV75D;Database=PracticaMigracion;Trusted_Connection=True;");
        }

        public DbSet<Equipos> Equipo { get; set; }
        public DbSet<Jugadores> Jugador { get; set; }
        public DbSet<TablaDeEstado> Estado { get; set; }
        public DbSet<PracticaMigracion.ViewModels.DetalleEquipo> DetalleEquipo { get; set; }
    }
}
