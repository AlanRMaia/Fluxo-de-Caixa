using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Application.Model
{
	public class LancamentoConsultaModel
	{
		
		public string Tipo { get; set; }	
		public DateTime DataLancamento { get; set; }
		public decimal ValorLancamento { get; set; }
	}
}
