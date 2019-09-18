using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;

namespace Project.Infra.Mappings
{
	public class LancamentosMap : IEntityTypeConfiguration<Lancamentos>
	{
		public void Configure(EntityTypeBuilder<Lancamentos> builder)
		{
			/*tipo_da_lancamento":"Tipos de lançamento(pagamento e recebimento)",
		"descricao": "Qualquer descrição sobre o pagamento",
		"conta_destino": "Conta do destinatário",
		"banco_destino": "Banco do destinatário",
		"tipo_de_conta": "Se a conta é corrente ou poupança",
		"cpf_cnpj_destino": "Numero formatado do CPF ou CNPJ",
		"valor_do_lancamento": "Valor em reais do lançamento no formato (R$ 0.000,00)",
		"data_de_lancamento": "Data em que a lançamento o ocorreu no formato (dd-mm-aaaa)"*/

			builder.HasKey(l => new { l.IdLancamento });

			builder.Property(l => l.Tipo)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(l => l.ContaDestino)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(l => l.BancoDestino)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(l => l.TipoConta)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(l => l.CpfCnpjDestino)
				.HasMaxLength(14)
				.IsRequired();

			builder.Property(l => l.ValorLancamento)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(l => l.DataLancamento)
				.HasColumnType("date")
				.IsRequired();

			builder.Property(l => l.Encargos)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(l => l.Descricao)
				.HasMaxLength(150)
				.IsRequired();
		}
	}
}
