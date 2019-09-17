	using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;


namespace Project.Domain.Contract.Services
{
	public interface IBaseDomainServices<TEntity> : IDisposable
		where TEntity : class
		
	{
		void Cadastrar(TEntity obj);
		void Atualizar(TEntity obj);
		void Excluir(TEntity obj);

		List<TEntity> ConsultarTodos();
		List<TEntity> ConsultarTodosDoDia(DateTime de, DateTime para);
		List<TEntity> ConsultarPorData(DateTime obj);

		TEntity ConsultarPorId(int id);


	}
}
