using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contract.Services;
using Project.Domain.Entities;
using Project.Application.Contracts;
using Project.Application.Model;
using AutoMapper;

namespace Project.Application.Services
{
	public class LancamentoApplicationServices : ILancamentoApplicationServices
	{
		private readonly ILancamentosServicos servicosDomain;

		public LancamentoApplicationServices(ILancamentosServicos servicosDomain)
		{
			this.servicosDomain = servicosDomain;
		}

		public void Cadastrar(LancamentoCadastroModel model)
		{
			var entity = Mapper.Map<Lancamentos>(model);
			servicosDomain.Cadastrar(entity);

		}

		public void Atualizar(LancamentoEdicaoModel model)
		{
			var entity = Mapper.Map<Lancamentos>(model);
			servicosDomain.Atualizar(entity);
		}

		public void Excluir(int id)
		{
			var entity = servicosDomain.ConsultarPorId(id);
			servicosDomain.Excluir(entity);
		}

		public List<LancamentoConsultaModel> ConsultarTodos()
		{
			var model = servicosDomain.ConsultarTodos();
			return Mapper.Map<List<LancamentoConsultaModel>>(model);
		}

		public List<LancamentoConsultaModel> ConsultarTodosDoDia(DateTime de, DateTime para)
		{
			var mes = servicosDomain.ConsultarTodosDoDia(de, para);

			return Mapper.Map<List<LancamentoConsultaModel>>(mes);
		}

		public List<LancamentoConsultaModel> ConsultarPorData(DateTime model)
		{
			var entity = servicosDomain.ConsultarPorData(model);

			return Mapper.Map<List<LancamentoConsultaModel>>(entity);
		}

		public LancamentoConsultaModel ConsultarPorId(int id)
		{
			var entity = servicosDomain.ConsultarPorId(id);
			return Mapper.Map<LancamentoConsultaModel>(entity);
		}

		public void Dispose()
		{
			servicosDomain.Dispose();
		}

		public List<LancamentoConsultaModel> ConsultarLayout(DateTime de, DateTime para)
		{
			var entity = servicosDomain.ConsultaLayout(de, para);
			return Mapper.Map<List<LancamentoConsultaModel>>(entity);
		}
	}
}
