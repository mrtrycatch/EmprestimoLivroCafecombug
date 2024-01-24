using EmprestimoLivrosNovo.API.Extensions;
using EmprestimoLivrosNovo.API.Models;
using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Application.Interfaces;
using EmprestimoLivrosNovo.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LivroController : Controller
    {

        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(LivroDTO livroDTO)
        {
            var livroDTOIncluido = await _livroService.Incluir(livroDTO);
            if (livroDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o livro.");
            }

            return Ok(new { message = "Livro incluído com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> Alterar(LivroDTO livroDTO)
        {
            var livroDTOAlterado = await _livroService.Alterar(livroDTO);
            if (livroDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o livro.");
            }

            return Ok(new { message = "Livro alterado com sucesso!" });
        }

        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            var livroDTOExcluido = await _livroService.Excluir(id);
            if (livroDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o livro.");
            }

            return Ok(new { message = "Livro excluído com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var livroDTO = await _livroService.SelecionarAsync(id);
            if (livroDTO == null)
            {
                return NotFound("Livro não encontrado.");
            }

            return Ok(livroDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos([FromQuery]PaginationParams paginationParams)
        {
            var livrosDTO = await _livroService.SelecionarTodosAsync(paginationParams.PageNumber,
                paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber,
                paginationParams.PageSize, livrosDTO.TotalCount, livrosDTO.TotalPages));

            return Ok(livrosDTO);
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult> SelecionarTodosByFiltro([FromQuery] FiltroLivro filtroLivro)
        {
            var livrosDTO = await _livroService.SelecionarByFiltroAsync(filtroLivro.Nome, filtroLivro.Autor,
                filtroLivro.Editora, filtroLivro.AnoPublicacao, filtroLivro.Edicao, filtroLivro.PageNumber,
                filtroLivro.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(filtroLivro.PageNumber,
                filtroLivro.PageSize, livrosDTO.TotalCount, livrosDTO.TotalPages));

            return Ok(livrosDTO);
        }
    }
}
