using System;
using System.Collections.Generic;
using System.Text;
using Project.Application.Model;

namespace Project.Application.Contracts
{
	public interface ILancamentoApplicationServices : IDisposable
	{
		void Cadastrar(LancamentoCadastroModel model);
		void Atualizar(LancamentoEdicaoModel model);
		void Excluir(int id);

		List<LancamentoConsultaModel> ConsultarTodos();
		List<LancamentoConsultaModel> ConsultarTodosDoDia(DateTime de, DateTime para);
		List<LancamentoConsultaModel> ConsultarLayout(DateTime de, DateTime para);
		List<LancamentoConsultaModel> ConsultarPorData(DateTime obj);


		LancamentoConsultaModel ConsultarPorId(int id);
	}
}
