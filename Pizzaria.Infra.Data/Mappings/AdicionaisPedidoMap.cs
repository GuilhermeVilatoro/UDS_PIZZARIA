using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Models;

namespace Pizzaria.Infra.Data.Mappings
{
    internal class AdicionaisPedidoMap : IEntityTypeConfiguration<AdicionaisPedido>
    {
        public void Configure(EntityTypeBuilder<AdicionaisPedido> builder)
        {
            builder.HasKey(p => new { p.PedidosId, p.AdicionaisPizzaId });

            builder.HasOne(p => p.Pedido)
               .WithMany()
               .HasForeignKey(p => p.PedidosId);

            builder.HasOne(p => p.AdicionalPizza)
               .WithMany()
               .HasForeignKey(p => p.AdicionaisPizzaId);
        }
    }
}