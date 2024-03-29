﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Infra.Context;

namespace Project.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Domain.Entities.ControleEncargos", b =>
                {
                    b.Property<int>("IdEncargo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BancoDestino")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("ContaDestino")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("CpfCnpjDestino")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Encargos")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("TipoConta")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("ValorLancamento")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdEncargo");

                    b.ToTable("ControleEncargos");
                });

            modelBuilder.Entity("Project.Domain.Entities.Lancamentos", b =>
                {
                    b.Property<int>("IdLancamento")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BancoDestino")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("ContaDestino")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("CpfCnpjDestino")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Encargos")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("TipoConta")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("ValorLancamento")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdLancamento");

                    b.ToTable("Lancamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
