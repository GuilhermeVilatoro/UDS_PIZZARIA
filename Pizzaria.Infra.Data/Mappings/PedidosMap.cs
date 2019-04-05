using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Models;

namespace Pizzaria.Infra.Data.Mappings
{
    internal class PedidosMap : IEntityTypeConfiguration<Pedidos>
    {
        public void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.SaborPizza)
               .WithMany()
               .HasForeignKey(p => p.SaboresPizzaId);

            builder.HasOne(p => p.TamanhoPizza)
               .WithMany()
               .HasForeignKey(p => p.TamanhoPizzaId);

            builder.Property(p => p.Total);

            builder.Property(p => p.Tempo);

            builder.Property(p => p.Finalizado);
        }
    }
}