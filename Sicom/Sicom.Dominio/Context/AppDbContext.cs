using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sicom.Dominio.Entidades;

namespace Sicom.Dominio.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineaCelular>()
            .HasOne(lc => lc.Modelo)
            .WithMany()
            .HasForeignKey(lc => lc.ModeloId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LineaAdministrativa>()
            .HasOne(lc => lc.Modulo)
            .WithMany()
            .HasForeignKey(lc => lc.ModuloId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LineaAdministrativa>()
            .HasOne(lc => lc.Pabellon)
            .WithMany()
            .HasForeignKey(lc => lc.PabellonId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LineaPublica>()
            .HasOne(lc => lc.Modulo)
            .WithMany()
            .HasForeignKey(lc => lc.ModuloId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LineaPublica>()
            .HasOne(lc => lc.Pabellon)
            .WithMany()
            .HasForeignKey(lc => lc.PabellonId)
            .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Establecimiento> Establecimientos { get; set; }
        public DbSet<EstadoLinea> EstadosLineas { get;set; }
        public DbSet<LineaAdministrativa> LineasAdministrativas { get; set; }
        public DbSet<LineaCelular> LineasCelulares { get; set; }
        public DbSet<LineaPublica> LineasPublicas { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<MarcaCelular> MarcasCelulares { get;set; }
        public DbSet<ModalidadLinea> ModalidadesLineas { get; set; }
        public DbSet<ModeloCelular> ModelosCelulares { get; set;}
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<OrigenServicio> OrigenesServicios { get; set; }
        public DbSet<Pabellon> Pabellones { get; set; }
        public DbSet<PrestadorServicio> PrestadoresServicios { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<TipoEquipoTelefonico> TiposEquiposTelefonicos { get; set; }

    }
}
