using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Services;
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
					entrada =+ item.ValorLancamento;
				}
				else
				{
					saida =+ item.ValorLancamento;
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

	}
}
