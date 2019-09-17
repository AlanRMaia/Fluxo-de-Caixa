using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;
using Project.Infra.Context;

namespace Project.Infra.Repositories
{
	public class LancamentosRepository :
		BaseRepository<Lancamentos>, ILancamentosRepositories
	{
		private readonly DataContext context;

		public LancamentosRepository(DataContext context)
			: base(context)
		{
			this.context = context;
		}

		public override List<Lancamentos> SelectAll(DateTime of, DateTime to)
		{
			return context.Lancamentos
				.Where(l => l.DataLancamento >= of && l.DataLancamento <= to)
				.OrderByDescending(l => l.DataLancamento)
				.ToList();
		}

		public override List<Lancamentos> SelectAllDate(DateTime obj)
		{
			return context.Lancamentos
				.Where(l => l.DataLancamento == obj)
				.OrderByDescending(l => l.DataLancamento)
				.ToList();
		}

	}
}
