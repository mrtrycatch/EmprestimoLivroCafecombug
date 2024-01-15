using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Application.Interfaces;
using EmprestimoLivrosNovo.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class SistemaController : Controller
    {

        private readonly IUsuarioService _usuarioService;
        private readonly ISistemaService _sistemaService;

        public SistemaController(IUsuarioService usuarioService, ISistemaService sistemaService)
        {
            _usuarioService = usuarioService;
            _sistemaService = sistemaService;
        }

        [HttpGet("VerificaPrimeiroUso")]
        public async Task<ActionResult> PrimeiroUso()
        {
            var existeUsuarioCadastrado = await _usuarioService.ExisteUsuarioCadastradoAsync();

            return Ok(new { primeiroUso = !existeUsuarioCadastrado });
        }

        [HttpGet("Dashboard")]
        [Authorize]
        public async Task<ActionResult> Dashboard()
        {
            var quantidadeItensDTO = await _sistemaService.SelecionarQtdItens();
            return Ok(quantidadeItensDTO);
        }
    }
}
