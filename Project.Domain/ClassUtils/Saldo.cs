using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;
using System.Timers;
using Project.Domain.Contract.Class;

namespace Project.Domain.ClassUtils
{
	public class Saldo : ISaldoUtils

	{
		private readonly  ILancamentosRepositories lancamentos;	
		

		public Saldo(ILancamentosRepositories lancamentos)
		{
			this.lancamentos = lancamentos;
		}

		public Saldo()
		{
		}

		public decimal ColsultarSaldoDia()
		{
			var timer = DateTime.Now.Date;

			var dia = lancamentos.SelectAllDate(timer);
			decimal saida = 0;
			decimal entrada = 0;
			decimal saldo;

			foreach (var item in dia)
			{

				if (item.Tipo.Contains("entrada"))
				{
					entrada = +item.ValorLancamento;
				}
				else
				{
					saida = +item.ValorLancamento;
				}

			}

			saldo = entrada - saida;

			return saldo;
		}

		public decimal ConsultaSaldoTotal()
		{
			var todos = lancamentos.SelectAll();

			decimal saida = 0;
			decimal entrada = 0;
			decimal saldo;

			foreach (var item in todos)
			{

				if (item.Tipo.Contains("entrada"))
				{
					entrada = +item.ValorLancamento;
				}
				else
				{
					saida = +item.ValorLancamento;
				}

			}

			saldo = entrada - saida;

			return saldo;

		}

		public decimal ColsultarSaldoDiaAnterior()
		{
			var timer = DateTime.Today.AddDays(-1);

			var dia = lancamentos.SelectAllDate(timer);
			decimal saida = 0;
			decimal entrada = 0;
			decimal saldo;

			foreach (var item in dia)
			{

				if (item.Tipo.Contains("entrada"))
				{
					entrada = +item.ValorLancamento;
				}
				else
				{
					saida = +item.ValorLancamento;
				}

			}

			saldo = entrada - saida;

			return saldo;
		}

		

		public List<Lancamentos> ConsultaLayout(DateTime de, DateTime para)
		{

			var conjuntos = lancamentos.SelectAll(de, para);

			var list = new List<Lancamentos>();
			var indice = new Lancamentos();


			foreach (var item in conjuntos)
			{

				indice.Tipo = item.Tipo;
				indice.DataLancamento = item.DataLancamento;
				indice.ValorLancamento = item.ValorLancamento;

				list.Add(indice);
			}

			return list;
		}

		
	}
}
