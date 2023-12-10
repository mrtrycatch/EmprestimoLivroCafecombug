using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Application.Interfaces;
using EmprestimoLivrosNovo.Infra.Ioc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : Controller
    {

        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(EmprestimoPostDTO emprestimoPostDTO)
        {
            emprestimoPostDTO.DataEmprestimo = DateTime.Now;
            emprestimoPostDTO.Entregue = false;
            var emprestimoDTOIncluido = await _emprestimoService.Incluir(emprestimoPostDTO);
            if (emprestimoDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o emprestimo.");
            }

            return Ok("Emprestimo incluído com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult> Alterar(EmprestimoPutDTO emprestimoPutDTO)
        {
            var emprestimoDTO = await _emprestimoService.SelecionarAsync(emprestimoPutDTO.Id);
            if (emprestimoDTO == null)
            {
                return NotFound("Empréstimo não encontrado.");
            }

            emprestimoDTO.DataEntrega = emprestimoPutDTO.DataEntrega;
            emprestimoDTO.Entregue = emprestimoPutDTO.Entregue;

            var emprestimoDTOAlterado = await _emprestimoService.Alterar(emprestimoDTO);
            if (emprestimoDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o emprestimo.");
            }

            return Ok("Emprestimo alterado com sucesso!");
        }

        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {

            var emprestimoDTOExcluido = await _emprestimoService.Excluir(id);
            if (emprestimoDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o emprestimo.");
            }

            return Ok("Emprestimo excluído com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var emprestimoDTO = await _emprestimoService.SelecionarAsync(id);
            if (emprestimoDTO == null)
            {
                return NotFound("Emprestimo não encontrado.");
            }

            return Ok(emprestimoDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos()
        {
            var emprestimosDTO = await _emprestimoService.SelecionarTodosAsync();
            return Ok(emprestimosDTO);
        }
    }
}
