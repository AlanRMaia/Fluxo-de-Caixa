using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;

namespace Project.Domain.Contract.Class
{
	public interface IEncargosUtils
		
	{
		void EncargosDia(Lancamentos lancamentos);

		void DeletarEncargo();

		List<ControleEncargos> SelecionaEncargos();
	}
}
