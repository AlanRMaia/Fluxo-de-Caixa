using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Project.Application.Model;
using Project.Domain.Entities;

namespace Project.Application.Adapters
{
	public class ModelToDomainEntity : Profile
	{
		public ModelToDomainEntity()
		{
			CreateMap<LancamentoCadastroModel, Lancamentos>();

			CreateMap<LancamentoEdicaoModel, Lancamentos>();
		}

	}
}
