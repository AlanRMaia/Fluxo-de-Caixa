using System;
using System.Collections.Generic;
using System.Text;


namespace Project.Domain.Entities
{
	public class Lancamentos
	{
		/*tipo_da_lancamento":"Tipos de lançamento(pagamento e recebimento)",
		"descricao": "Qualquer descrição sobre o pagamento",
		"conta_destino": "Conta do destinatário",
		"banco_destino": "Banco do destinatário",
		"tipo_de_conta": "Se a conta é corrente ou poupança",
		"cpf_cnpj_destino": "Numero formatado do CPF ou CNPJ",
		"valor_do_lancamento": "Valor em reais do lançamento no formato (R$ 0.000,00)",
		"data_de_lancamento": "Data em que a lançamento o ocorreu no formato (dd-mm-aaaa)"*/
		public int IdLancamento { get; set; }
		public string Tipo { get; set; }
		public string Descricao { get; set; }
		public string ContaDestino { get; set; }
		public string BancoDestino { get; set; }
		public string TipoConta { get; set; }
		public string CpfCnpjDestino { get; set; }
		public decimal ValorLancamento { get; set; }
		public DateTime DataLancamento { get; set; }
		public double Encargos { get; set; }


	}
}
