using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.ClassUtils;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;

namespace Project.Domain.Contract.Class
{
	public interface ISaldoUtils
	
	{
		decimal ColsultarSaldoDia();

		decimal ConsultaSaldoTotal();

		decimal ColsultarSaldoDiaAnterior();

		List<Lancamentos> ConsultaLayout(DateTime de, DateTime para);
	}

}

	
