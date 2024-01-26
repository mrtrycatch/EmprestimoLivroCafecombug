using EmprestimoLivrosNovo.API.Extensions;
using EmprestimoLivrosNovo.API.Models;
using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Application.Interfaces;
using EmprestimoLivrosNovo.Application.Services;
using EmprestimoLivrosNovo.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmprestimoController : Controller
    {

        private readonly IEmprestimoService _emprestimoService;
        private readonly ILivroEmprestadoService _livroEmprestadoService;

        public EmprestimoController(IEmprestimoService emprestimoService, ILivroEmprestadoService livroEmprestadoService)
        {
            _emprestimoService = emprestimoService;
            _livroEmprestadoService = livroEmprestadoService;
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(EmprestimoPostDTO emprestimoPostDTO)
        {

            var disponivel = await _emprestimoService.VerificaDisponibilidadeAsync(emprestimoPostDTO.idsLivros);
            if (!disponivel)
            {
                return BadRequest("O livro não está disponível para empréstimo.");
            }

            emprestimoPostDTO.DataEmprestimo = DateTime.Now;
            emprestimoPostDTO.Entregue = false;
            var emprestimoDTOIncluido = await _emprestimoService.Incluir(emprestimoPostDTO);
            if (emprestimoDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o emprestimo.");
            }
            else
            {
                List<LivroEmprestadoDTO> livrosEmprestadosDTO = new  List<LivroEmprestadoDTO>();
                LivroEmprestadoDTO livroEmprestado;
                foreach(var idLivroEmprestado in emprestimoPostDTO.idsLivros)
                {
                    livroEmprestado = new LivroEmprestadoDTO
                    {
                        IdEmprestimo = emprestimoDTOIncluido.Id,
                        IdLivro = idLivroEmprestado
                    };
                    livrosEmprestadosDTO.Add(livroEmprestado);
                }

                await _livroEmprestadoService.IncluirVariosAsync(livrosEmprestadosDTO);
            }

            return Ok(new { message = "Emprestimo incluído com sucesso!" });
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
            emprestimoDTO.IdCliente = emprestimoPutDTO.IdCliente;

            var emprestimoDTOAlterado = await _emprestimoService.Alterar(emprestimoDTO);
            if (emprestimoDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o emprestimo.");
            }
            else
            {
                List<LivroEmprestadoDTO> livrosEmprestadosDTO = new List<LivroEmprestadoDTO>();
                LivroEmprestadoDTO livroEmprestado;
                foreach (var idLivroEmprestado in emprestimoPutDTO.idsLivros)
                {
                    livroEmprestado = new LivroEmprestadoDTO
                    {
                        IdEmprestimo = emprestimoDTOAlterado.Id,
                        IdLivro = idLivroEmprestado
                    };
                    livrosEmprestadosDTO.Add(livroEmprestado);
                }

                await _livroEmprestadoService.SubstituirTodosAsync(livrosEmprestadosDTO);

            }

            return Ok(new { message = "Emprestimo alterado com sucesso!" });
        }

        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {

            var emprestimoDTOExcluido = await _emprestimoService.Excluir(id);
            if (emprestimoDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o emprestimo.");
            }

            return Ok(new { message = "Emprestimo excluído com sucesso!" });
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
        public async Task<ActionResult> SelecionarTodos([FromQuery]PaginationParams paginationParams)
        {
            var emprestimosDTO = await _emprestimoService.SelecionarTodosAsync
                (paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber,
                paginationParams.PageSize, emprestimosDTO.TotalCount, emprestimosDTO.TotalPages));

            return Ok(emprestimosDTO);
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult> SelecionarTodosByFiltro([FromQuery] FiltroEmprestimo filtroEmprestimo)
        {
            var emprestimosDTO = await _emprestimoService.SelecionarByFiltroAsync
                (filtroEmprestimo.Cpf, filtroEmprestimo.Nome,
                 filtroEmprestimo.DataEmprestimoInicio, filtroEmprestimo.DataEmprestimoFim,
                 filtroEmprestimo.DataEntregaInicio, filtroEmprestimo.DataEntregaFim,
                 filtroEmprestimo.Entregue, filtroEmprestimo.NaoEntregue, filtroEmprestimo.PageNumber, filtroEmprestimo.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(filtroEmprestimo.PageNumber,
                filtroEmprestimo.PageSize, emprestimosDTO.TotalCount, emprestimosDTO.TotalPages));

            return Ok(emprestimosDTO);
        }
    }
}
