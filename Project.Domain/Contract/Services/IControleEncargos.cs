﻿using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;

namespace Project.Domain.Contract.Services
{
	public interface IControleEncargos :
		IBaseDomainServices<ControleEncargos>
	{
		void EncargosDia(Lancamentos lancamentos);

		void DeletarEncargo();

		List<ControleEncargos> SelecionaEncargos();

	}
}
