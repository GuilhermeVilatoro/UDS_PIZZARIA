using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pizzaria.Domain.Models;
using Pizzaria.Infra.Data.Mappings;
using System.IO;

namespace Pizzaria.Infra.Data.Context
{
    public class PizzariaContext : DbContext
    {
        public DbSet<SaboresPizza> SaboresPizza { get; set; }

        public DbSet<TamanhosPizza> TamanhosPizza { get; set; }

        public DbSet<AdicionaisPizza> AdicionaisPizza { get; set; }

        public DbSet<Pedidos> Pedidos { get; set; }

        public DbSet<AdicionaisPedido> AdicionaisPedido { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SaboresPizzaMap());
            modelBuilder.ApplyConfiguration(new TamanhosPizzaMap());
            modelBuilder.ApplyConfiguration(new AdicionaisPizzaMap());
            modelBuilder.ApplyConfiguration(new PedidosMap());            

            modelBuilder.Entity<AdicionaisPedido>().HasKey(sc => new { sc.PedidosId, sc.AdicionaisPizzaId });

            modelBuilder.Entity<AdicionaisPedido>()
                .HasOne<Pedidos>(sc => sc.Pedidos)
                .WithMany(s => s.AdicionaisPedido)
                .HasForeignKey(sc => sc.PedidosId);

            modelBuilder.Entity<AdicionaisPedido>()
                .HasOne<AdicionaisPizza>(sc => sc.AdicionaisPizza)
                .WithMany(s => s.AdicionaisPedido)
                .HasForeignKey(sc => sc.AdicionaisPizzaId);            

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();            

            // define the database to use ver docker
            //optionsBuilder.UseInMemoryDatabase();

            optionsBuilder.UseSqlServer(config.GetConnectionString("PizzariaContext"));
        }
    }
}