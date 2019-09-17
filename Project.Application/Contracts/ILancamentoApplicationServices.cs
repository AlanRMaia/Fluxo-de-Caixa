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
		LancamentoConsultaModel ConsultaPorId(int id);
	}
}
