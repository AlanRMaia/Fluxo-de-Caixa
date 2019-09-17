using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Application.Model
{
	public class LancamentoConsultaModel
	{
		public int IdLancamento { get; set; }
		public string Tipo { get; set; }
		public string Descricao { get; set; }
		public string ContaDestino { get; set; }
		public string BancoDestino { get; set; }
		public string TipoConta { get; set; }
		public string CpfCnpjDestino { get; set; }
		public decimal ValorLancamento { get; set; }
		public DateTime DataLancamento { get; set; }
	}
}
