using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;
using Project.Domain.Contract.Services;

namespace Project.Domain.Services
{

	public class LancamentosDomainServices :
		BaseDomainServices<Lancamentos>, ILancamentosServicos
	{
		private readonly ILancamentosRepositories repositories;
		private readonly IControleEncargos controleEncargos;

		public LancamentosDomainServices(ILancamentosRepositories repositories, IControleEncargos controleEncargos)
			: base(repositories)
		{
			this.repositories = repositories;
			this.controleEncargos = controleEncargos;
		}



		public override void Cadastrar(Lancamentos obj)
		{
			if (ConsultaSaldoTotal() <= - 20000)
			{
				return;
			}
			else if (ConsultaSaldoTotal() < 0 && ConsultaSaldoTotal() > -20000)
			{		

				controleEncargos.EncargosDia(obj);
			}

			repositories.Insert(obj);
		}



		public decimal ColsultarSaldoDia()
		{
			var timer = DateTime.Now.Date;

			var dia = repositories.SelectAllDate(timer);
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
			var todos = repositories.SelectAll();

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

			var dia = repositories.SelectAllDate(timer);
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

			var conjuntos = repositories.SelectAll(de, para);

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
		public void EncontrarEncargo()
		{
			if (ConsultaSaldoTotal() >= 0)
			{
				controleEncargos.DeletarEncargo();
			}
		}
}
}

