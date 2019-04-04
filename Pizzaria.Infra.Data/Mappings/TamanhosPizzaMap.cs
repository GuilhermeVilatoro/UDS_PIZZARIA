using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Models;

namespace Pizzaria.Infra.Data.Mappings
{
    internal class TamanhosPizzaMap : IEntityTypeConfiguration<TamanhosPizza>
    {
        public void Configure(EntityTypeBuilder<TamanhosPizza> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Tamanho)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Valor)
                .IsRequired();

            builder.Property(p => p.Tempo)                
                .IsRequired();
        }
    }
}