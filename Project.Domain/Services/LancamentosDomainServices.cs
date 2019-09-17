using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;
using Project.Domain.Contract.Services;
using Project.Domain.ClassUtils;

namespace Project.Domain.Services
{

	public class LancamentosDomainServices :
		BaseDomainServices<Lancamentos>, ILancamentosServicos
	{
		private readonly ILancamentosRepositories repositories;


		public LancamentosDomainServices(ILancamentosRepositories repositories)
			: base(repositories)
		{
			this.repositories = repositories;

		}

		Saldo saldo = new Saldo();

		public override void Cadastrar(Lancamentos obj)
		{
			if (saldo.ConsultaSaldoTotal() <= - 20000)
			{

			}
			else if (saldo.ConsultaSaldoTotal() < 0 && saldo.ConsultaSaldoTotal() > -20000)
			{
				Encargos encargos = new Encargos();

				encargos.EncargosDia(obj);
			}

			repositories.Insert(obj);
		}

		public decimal ConsultarSaldoDia()
		{
			return saldo.ColsultarSaldoDia();
		}

		public decimal ConsultarSaldoTotal()
		{
			return saldo.ConsultaSaldoTotal();
		}

		public List<Lancamentos> ConsultaLeyout(DateTime de, DateTime para)
		{
			return saldo.ConsultaLayout(de, para);
		}
	}
}

