using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;

namespace Project.Domain.Contract.Services
{
	public interface ILancamentosServicos :
		IBaseDomainServices<Lancamentos>
	{	
		

		decimal ColsultarSaldoDia();

		decimal ConsultaSaldoTotal();

		decimal ColsultarSaldoDiaAnterior();

		void EncontrarEncargo();

		List<Lancamentos> ConsultaLayout(DateTime de, DateTime para);

	}
}
