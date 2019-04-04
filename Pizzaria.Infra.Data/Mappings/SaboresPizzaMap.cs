using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Domain.Models;

namespace Pizzaria.Infra.Data.Mappings
{
    internal class SaboresPizzaMap : IEntityTypeConfiguration<SaboresPizza>
    {
        public void Configure(EntityTypeBuilder<SaboresPizza> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Sabor)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.TempoAdicional);               
        }
    }
}