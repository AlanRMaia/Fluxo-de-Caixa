using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;


namespace Project.Infra.Mappings
{
	public class ControleEncargosMap : IEntityTypeConfiguration<ControleEncargos>
	{
		public void Configure(EntityTypeBuilder<ControleEncargos> builder)
		{
			builder.HasKey(c => new { c.IdEncargo});			

			builder.Property(c => c.Tipo)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(c => c.ContaDestino)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(c => c.BancoDestino)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(c => c.TipoConta)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(c => c.CpfCnpjDestino)
				.HasMaxLength(14)
				.IsRequired();

			builder.Property(c => c.ValorLancamento)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(c => c.DataLancamento)
				.HasColumnType("date")
				.IsRequired();

			builder.Property(c => c.Encargos)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(c => c.Descricao)
				.HasMaxLength(150)
				.IsRequired();
				


		}
	}
}
