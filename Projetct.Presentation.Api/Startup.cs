using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.Application.Adapters;
using Project.Infra.Context;
using Swashbuckle.AspNetCore.Swagger;
using Project.Application.Contracts;
using Project.Application.Services;
using Project.Domain.Contract.Services;
using Project.Domain.Services;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;
using Project.Infra.Repositories;
using System.Threading;


namespace Projetct.Presentation.Api
{


	public class Startup
	{		

		public Startup(IConfiguration configuration)
		{

			Configuration = configuration;

		/*	#region Rotina de verificação de saldo negativo		

			List<ControleEncargos> list;

			do
			{
				Thread.Sleep(5000);

				saldo.EncontrarEncargo();

				list = encargos.SelecionaEncargos();
			} while (list == null);
			#endregion*/
		}



		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			#region Configuração para EntityFrameWork			

			//mapeando injeção de dependência para a classe DataContext
			services.AddTransient<DataContext>();

			//mapeando a string de conexão que será enviada para a classe DataContext
			services.AddDbContext<DataContext>(
					options => options.UseSqlServer(Configuration.GetConnectionString("Conexao"))
				);

			#endregion

			#region Configuração para Injeção de Dependência

			//camada de aplicação
			services.AddTransient<ILancamentoApplicationServices, LancamentoApplicationServices>();

			//camada de dominio
			services.AddTransient<ILancamentosServicos, LancamentosDomainServices>();
			services.AddTransient<IControleEncargos, ControleEncargosDomainServices>();

			//camada de infra estrutura do repositorio
			services.AddTransient<ILancamentosRepositories, LancamentosRepository>();
			services.AddTransient<IControleEncargosRepositories, ControleEncargosRepository>();

			#endregion

			#region Configuração para o AutoMapper

			AutoMapperConfig.Register();

			#endregion

			#region Configuração para o SWAGGER

			services.AddSwaggerGen(
					swagger =>
					{
						swagger.SwaggerDoc("v1",
							new Info
							{
								Title = "Sistema de Fluxo de Caixa",
								Version = "v1",
								Description = "Projeto desenvolvido Alan Maia",
								Contact = new Contact
								{
									Name = "Alan Rodrigues Maia",
									Email = "alanr.maia@hotmail.com"

								}
							});
					}
				);

			#endregion

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();

			#region Configuração para o SWAGGER

			app.UseSwagger(); //definindo o uso do Swagger para o projeto
			app.UseSwaggerUI(
					swagger =>
					{
						swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
					}
				);

			#endregion
		}
	}
}
