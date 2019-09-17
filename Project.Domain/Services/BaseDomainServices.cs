using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contract.Services;
using Project.Domain.Contract.Repositories;

namespace Project.Domain.Services
{
	public class BaseDomainServices<TEntity> :
		IBaseDomainServices<TEntity> where TEntity : class
	{
		private readonly IBaseRepositories<TEntity> repositories;

		public BaseDomainServices(IBaseRepositories<TEntity> repositories)
		{
			this.repositories = repositories;
		}

		public virtual void Cadastrar(TEntity obj)
		{
			repositories.Insert(obj);
		}

		public virtual void Atualizar(TEntity obj)
		{
			repositories.Update(obj);
		}

		public virtual void Excluir(TEntity obj)
		{
			repositories.Delete(obj);
		}

		public virtual List<TEntity> ConsultarTodos()
		{
			return repositories.SelectAll();
		}

		public virtual List<TEntity> ConsultarTodosDoDia(DateTime de, DateTime para)
		{
			return repositories.SelectAll(de, para);
		}

		public virtual List<TEntity> ConsultarPorData(DateTime obj)
		{
			return repositories.SelectAllDate(obj);
		}

		public virtual void Dispose()
		{
			repositories.Dispose();
		}

		public virtual TEntity ConsultarPorId(int id)
		{
			return repositories.SelectOne(id);
		}
	}
	
}
