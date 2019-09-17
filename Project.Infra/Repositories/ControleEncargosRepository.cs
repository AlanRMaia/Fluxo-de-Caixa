using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;
using Project.Domain.Contract.Repositories;
using Project.Infra.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project.Infra.Repositories
{
	public class ControleEncargosRepository : 
		BaseRepository<ControleEncargos>, IControleEncargosRepositories
	{
		private readonly DataContext context;

		public ControleEncargosRepository(DataContext context):
			base(context)
		{
			this.context = context;
		}

		public override ControleEncargos SelectOne(DateTime obj)
		{
			return context.ControleEncargos
				.SingleOrDefault(c => c.DataLancamento.Equals(obj));
				
		}

		public override ControleEncargos SelectOne(int id)
		{
			return context.ControleEncargos
				.SingleOrDefault(c => c.IdEncargo.Equals(id));
		}
	}
}
