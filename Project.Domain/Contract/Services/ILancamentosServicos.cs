using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;

namespace Project.Domain.Contract.Services
{
	public interface ILancamentosServicos :
		IBaseDomainServices<Lancamentos>
	{
		decimal ConsultarSaldoDia();
		decimal ConsultarSaldoTotal();
		List<Lancamentos> ConsultaLeyout(DateTime de, DateTime para);

	}
}
