using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LivroEmprestadoController : Controller
    {

        private readonly ILivroEmprestadoService _livroEmprestadoService;

        public LivroEmprestadoController(ILivroEmprestadoService livroEmprestadoService)
        {
            _livroEmprestadoService = livroEmprestadoService;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            await _livroEmprestadoService.Excluir(id);
            return Ok(new { message = "Livro removido do empréstimo com sucesso!" });
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(LivroEmprestadoDTO livroEmprestadoDTO)
        {
            await _livroEmprestadoService.Incluir(livroEmprestadoDTO);
            return Ok(new { message = "Livro incluído no empréstimo com sucesso!" });
        }

        [HttpGet("emprestimo/{id}")]
        public async Task<ActionResult> SelecionarTodosByEmprestimo(int id)
        {
            var livrosEmprestados = await _livroEmprestadoService.SelecionarTodosByEmprestimoAsync(id);
            return Ok(livrosEmprestados);
        }
    }
}
