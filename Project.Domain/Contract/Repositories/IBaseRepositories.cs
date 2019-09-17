using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Contract.Repositories
{
	public interface IBaseRepositories<TEntity> : IDisposable
		where TEntity : class
	{
		void Insert(TEntity obj);
		void Update(TEntity obj);
		void Delete(TEntity obj);

		List<TEntity> SelectAll();
		List<TEntity> SelectAll(DateTime of, DateTime to);
		List<TEntity> SelectAllDate(DateTime obj);

		TEntity SelectOne(int id);
		TEntity SelectOne(DateTime obj);

		int Count();
		int Count(DateTime obj);

	}
}
