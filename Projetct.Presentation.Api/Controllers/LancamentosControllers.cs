using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Project.Application.Contracts;
using Project.Application.Model;

namespace Projetct.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosControllers : ControllerBase
    {

		private readonly ILancamentoApplicationServices lancamentoApplication;

		public LancamentosControllers(ILancamentoApplicationServices lancamentoApplication)
		{
			this.lancamentoApplication = lancamentoApplication;
		}


		[HttpPost]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(500, Type = typeof(string))]
		[ProducesResponseType(400)]
		public IActionResult Post([FromBody] LancamentoCadastroModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					lancamentoApplication.Cadastrar(model);
					return Ok($"Lancamento tipo {model.Tipo}, cadastrado com sucesso.");
				}
				catch (Exception e)
				{
					return StatusCode(500, e.Message);
				}
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(500, Type = typeof(string))]
		[ProducesResponseType(400)]
		public IActionResult Put([FromBody] LancamentoEdicaoModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					lancamentoApplication.Atualizar(model);
					return Ok($"Lancamento {model.Tipo}, atualizado com sucesso.");
				}
				catch (Exception e)
				{
					return StatusCode(500, e.Message);
				}
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(500, Type = typeof(string))]
		public IActionResult Delete(int id)
		{
			try
			{
				lancamentoApplication.Excluir(id);
				return Ok("Lancamento excluído com sucesso.");
			}
			catch (Exception e)
			{
				return StatusCode(500, e.Message);
			}
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<LancamentoConsultaModel>))]
		[ProducesResponseType(500, Type = typeof(string))]
		public IActionResult Get()
		{
			try
			{
				var result = lancamentoApplication.ConsultarTodos();
				return Ok(result);
			}
			catch (Exception e)
			{
				return StatusCode(500, e.Message);
			}
		}

		[HttpGet("{}")]
		[ProducesResponseType(200, Type = typeof(LancamentoConsultaModel))]
		[ProducesResponseType(500, Type = typeof(string))]
		public IActionResult Get(LancamentoConsultaModel model)
		{
			try
			{

				var result = lancamentoApplication.ConsultarLayout(DateTime.Now, DateTime.Now.AddMonths(1));
				return Ok(result);
			}
			catch (Exception e)
			{
				return StatusCode(500, e.Message);
			}
		}

		/*[HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(LancamentoConsultaModel))]
		[ProducesResponseType(500, Type = typeof(string))]
		public IActionResult Get(int id)
		{
			try
			{
				var result = lancamentoApplication.ConsultaPorId(id);
				return Ok(result);
			}
			catch (Exception e)
			{
				return StatusCode(500, e.Message);
			}
		}*/
	}
}