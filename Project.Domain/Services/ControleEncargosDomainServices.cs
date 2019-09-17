using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;
using Project.Domain.Contract.Services;

namespace Project.Domain.Services
{
	public class ControleEncargosDomainServices : 
		BaseDomainServices<ControleEncargos>, IControleEncargos
	{

		private readonly IControleEncargosRepositories repositories;

		public ControleEncargosDomainServices(IControleEncargosRepositories repositories) 
			:base(repositories)
		{
			this.repositories = repositories;
		}

			
	}
}
