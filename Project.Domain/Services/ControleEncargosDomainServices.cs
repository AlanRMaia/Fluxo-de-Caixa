using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;
using Project.Domain.Contract.Services;
using System.Threading;

namespace Project.Domain.Services
{
	public class ControleEncargosDomainServices : 
		BaseDomainServices<ControleEncargos>, IControleEncargos
	{

		private readonly LancamentosDomainServices saldo;
		private readonly IControleEncargosRepositories repositories;

		public ControleEncargosDomainServices(IControleEncargosRepositories repositories, LancamentosDomainServices saldo)
			: base(repositories)
		{
			this.repositories = repositories;
			this.saldo = saldo;
		}


		public void EncargosDia(Lancamentos lancamentos)
		{			

			ControleEncargos encargos = new ControleEncargos();

			var porcentagem = (double)saldo.ConsultaSaldoTotal();


			lancamentos.Tipo = "saida";
			lancamentos.ValorLancamento = (decimal)(0.83 * (porcentagem / 100));

			saldo.Cadastrar(lancamentos);

			encargos.BancoDestino = lancamentos.BancoDestino;
			encargos.ContaDestino = lancamentos.ContaDestino;
			encargos.CpfCnpjDestino = lancamentos.CpfCnpjDestino;
			encargos.DataLancamento = lancamentos.DataLancamento;
			encargos.Descricao = lancamentos.Descricao;
			encargos.Tipo = lancamentos.Tipo;
			encargos.TipoConta = lancamentos.TipoConta;
			encargos.ValorLancamento = lancamentos.ValorLancamento;


			repositories.Insert(encargos);

			List<ControleEncargos> list;
			//rotina 24hs para verificar se o o saldo ainda está menor do que 0
			do
			{

				Thread.Sleep(TimeSpan.FromHours(24));

				if (saldo.ConsultaSaldoTotal() >= 0)
				{
					var id = repositories.SelectOne(1);
					repositories.Delete(id);
				}

				list = repositories.SelectAll();

			} while (list == null);



		}

		public void DeletarEncargo()
		{
			var id = repositories.SelectOne(1);
			repositories.Delete(id);
		}

		public List<ControleEncargos> SelecionaEncargos()
		{

			return repositories.SelectAll();
		}


	}
}
