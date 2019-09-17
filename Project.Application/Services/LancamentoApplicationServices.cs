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
			var entityList = servicosDomain.ConsultarTodos();
			return Mapper.Map<List<LancamentoConsultaModel>>(entityList);
			
		}

		public LancamentoConsultaModel ConsultaPorId(int id)
		{
			var entity = servicosDomain.ConsultarPorId(id);
			return Mapper.Map<LancamentoConsultaModel>(entity);
		}

		public void Dispose()
		{
			servicosDomain.Dispose();
		}
	}
}
