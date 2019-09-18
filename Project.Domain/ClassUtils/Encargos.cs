﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Project.Domain.Services;
using Project.Domain.Entities;
using Project.Domain.ClassUtils;
using Project.Domain.Contract.Class;
using Project.Domain.Contract.Repositories;

namespace Project.Domain.ClassUtils
{
	public class Encargos : IEncargosUtils
	{
		//"encargos": "Valor em reais dos encargos do lançamento no formato (R$ 0.000,00)"
		
		private readonly ILancamentosRepositories repositories;
		private readonly IControleEncargosRepositories encargosRepositories;

		public Encargos(ILancamentosRepositories repositories, IControleEncargosRepositories encargosRepositories)
		{
			
			this.repositories = repositories;
			this.encargosRepositories = encargosRepositories;
		}

		public Encargos()
		{

		}
		public void EncargosDia(Lancamentos lancamentos)
		{
			var saldo = new Saldo();

			ControleEncargos encargos = new ControleEncargos();

			var porcentagem = (double)saldo.ConsultaSaldoTotal();


			lancamentos.Tipo = "saida";
			lancamentos.ValorLancamento = (decimal)(0.83 * (porcentagem / 100));

			repositories.Insert(lancamentos);		

			encargos.BancoDestino =  lancamentos.BancoDestino;
			encargos.ContaDestino = lancamentos.ContaDestino;
			encargos.CpfCnpjDestino = lancamentos.CpfCnpjDestino;
			encargos.DataLancamento = lancamentos.DataLancamento;
			encargos.Descricao = lancamentos.Descricao;
			encargos.Tipo = lancamentos.Tipo;
			encargos.TipoConta = lancamentos.TipoConta;
			encargos.ValorLancamento = lancamentos.ValorLancamento;

			
			encargosRepositories.Insert(encargos);      
			
			List<ControleEncargos> list;
			//rotina 24hs para verificar se o o saldo ainda está menor do que 0
			do
			{
				
				Thread.Sleep(TimeSpan.FromHours(24));

				if (saldo.ConsultaSaldoTotal() >= 0 )
				{
					var id = encargosRepositories.SelectOne(1);
					encargosRepositories.Delete(id);
				}

				list = encargosRepositories.SelectAll();
				
			} while (list == null);		



		}

		public void DeletarEncargo()
		{
			var id = encargosRepositories.SelectOne(1);
			encargosRepositories.Delete(id);
		}

		public List<ControleEncargos> SelecionaEncargos()
		{

			return encargosRepositories.SelectAll();
		}


	}
}
