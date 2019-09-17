﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Project.Application.Model;
using Project.Domain.Entities;

namespace Project.Application.Adapters
{
	public class DomainEntityToModel : Profile
	{
		public DomainEntityToModel()
		{

			CreateMap<Lancamentos, LancamentoConsultaModel>();

		}
	}
}
