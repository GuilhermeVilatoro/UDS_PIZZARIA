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

            builder.HasOne(p => p.SaboresPizza)
               .WithMany(sp => sp.Pedidos)
               .HasForeignKey(p => p.SaboresPizzaId);

            builder.HasOne(p => p.TamanhosPizza)
               .WithMany(t => t.Pedidos)
               .HasForeignKey(p => p.TamanhosPizzaId);

            builder.Property(p => p.Total);

            builder.Property(p => p.Tempo);

            builder.Property(p => p.Finalizado);
        }
    }
}