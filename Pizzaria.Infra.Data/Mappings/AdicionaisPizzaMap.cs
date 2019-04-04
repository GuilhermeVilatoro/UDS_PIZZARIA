using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Models;

namespace Pizzaria.Infra.Data.Mappings
{
    internal class AdicionaisPizzaMap : IEntityTypeConfiguration<AdicionaisPizza>
    {
        public void Configure(EntityTypeBuilder<AdicionaisPizza> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Adicional)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Valor);

            builder.Property(p => p.Tempo);                
        }
    }
}