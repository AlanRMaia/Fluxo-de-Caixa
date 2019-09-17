using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Services;
using Project.Domain.Entities;
using System.Timers;

namespace Project.Domain.ClassUtils
{
	public class Saldo
	{
		private readonly LancamentosDomainServices lancamentos;

		public Saldo(LancamentosDomainServices lancamentos)
		{
			this.lancamentos = lancamentos;
		}


		public Saldo()
		{

		}

		public decimal ColsultarSaldoDia()
		{
			var timer = DateTime.Now.Date;

			var dia = lancamentos.ConsultarPorData(timer);
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
			var todos = lancamentos.ConsultarTodos();

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

			var dia = lancamentos.ConsultarPorData(timer);
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

			var conjuntos = lancamentos.ConsultarTodosDoDia(de, para);

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
