﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzaria.Infra.Data.Context;

namespace Pizzaria.Infra.Data.Migrations
{
    [DbContext(typeof(PizzariaContext))]
    [Migration("20190406183953_CriacaoTabelaAdicionaisPedido")]
    partial class CriacaoTabelaAdicionaisPedido
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pizzaria.Domain.Models.AdicionaisPedido", b =>
                {
                    b.Property<int>("PedidosId");

                    b.Property<int>("AdicionaisPizzaId");

                    b.HasKey("PedidosId", "AdicionaisPizzaId");

                    b.HasIndex("AdicionaisPizzaId");

                    b.ToTable("AdicionaisPedido");
                });

            modelBuilder.Entity("Pizzaria.Domain.Models.AdicionaisPizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adicional")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int?>("Tempo");

                    b.Property<decimal?>("Valor");

                    b.HasKey("Id");

                    b.ToTable("AdicionaisPizza");
                });

            modelBuilder.Entity("Pizzaria.Domain.Models.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Finalizado");

                    b.Property<int>("SaboresPizzaId");

                    b.Property<int>("TamanhosPizzaId");

                    b.Property<int>("Tempo");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("SaboresPizzaId");

                    b.HasIndex("TamanhosPizzaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Pizzaria.Domain.Models.SaboresPizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Sabor")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("TempoAdicional");

                    b.HasKey("Id");

                    b.ToTable("SaboresPizza");
                });

            modelBuilder.Entity("Pizzaria.Domain.Models.TamanhosPizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Tempo");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("TamanhosPizza");
                });

            modelBuilder.Entity("Pizzaria.Domain.Models.AdicionaisPedido", b =>
                {
                    b.HasOne("Pizzaria.Domain.Models.AdicionaisPizza", "AdicionaisPizza")
                        .WithMany("AdicionaisPedido")
                        .HasForeignKey("AdicionaisPizzaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pizzaria.Domain.Models.Pedidos", "Pedidos")
                        .WithMany("AdicionaisPedido")
                        .HasForeignKey("PedidosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pizzaria.Domain.Models.Pedidos", b =>
                {
                    b.HasOne("Pizzaria.Domain.Models.SaboresPizza", "SaboresPizza")
                        .WithMany("Pedidos")
                        .HasForeignKey("SaboresPizzaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pizzaria.Domain.Models.TamanhosPizza", "TamanhosPizza")
                        .WithMany("Pedidos")
                        .HasForeignKey("TamanhosPizzaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
