using EmprestimoLivrosNovo.API.Extensions;
using EmprestimoLivrosNovo.API.Models;
using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Application.Interfaces;
using EmprestimoLivrosNovo.Domain.Account;
using EmprestimoLivrosNovo.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO)
        {

            if (usuarioDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            var emailExiste = await _authenticateService.UserExists(usuarioDTO.Email);

            if (emailExiste)
            {
                return BadRequest("Este e-mail já possui um cadastro.");
            }

            var existeUsuarioSistema = await _usuarioService.ExisteUsuarioCadastradoAsync();

            if (!existeUsuarioSistema)
            {
                usuarioDTO.IsAdmin = true;
            }
            else
            {
                if (User.FindFirst("id") == null)
                {
                    return Unauthorized();
                }

                var userId = User.GetId();
                var user = await _usuarioService.SelecionarAsync(userId);
                if (!user.IsAdmin)
                {
                    return Unauthorized("Você não tem permissão para incluir novos usuários.");
                }
            }


            var usuario = await _usuarioService.Incluir(usuarioDTO);
            if (usuario == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar.");
            }

            //var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);
            //return new UserToken
            //{
            //    Token = token
            //};

            return Ok(new {message = "Usuário incluído com sucesso!"});

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Selecionar(LoginModel loginModel)
        {
            var existe = await _authenticateService.UserExists(loginModel.Email);
            if (!existe)
            {
                return Unauthorized("Usuário não existe.");
            }

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result)
            {
                return Unauthorized("Usuário ou senha inválido.");
            }

            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token,
                IsAdmin = usuario.IsAdmin,
                Email = usuario.Email
            };
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> SelecionarTodos([FromQuery] PaginationParams paginationParams)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);

            if (!user.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var usuarios = await _usuarioService.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, usuarios.PageSize,
                usuarios.TotalCount, usuarios.TotalPages));
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> SelecionarById(int id)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);

            if (id == 0)
            {
                id = userId;
            }

            if (!user.IsAdmin && user.Id != id)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var usuario = await _usuarioService.SelecionarAsync((int)id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int id)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);

            if (!user.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para excluir os usuários do sistema.");
            }

            var usuario = await _usuarioService.Excluir(id);
            return Ok(usuario);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Alterar(UsuarioPutDTO usuarioPutDTO)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);


            if (!user.IsAdmin && usuarioPutDTO.Id != userId)
            {
                return Unauthorized("Você não tem permissão para alterar os usuários do sistema.");
            }

            if (!user.IsAdmin && usuarioPutDTO.Id == userId && usuarioPutDTO.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para definir você mesmo como administrador.");
            }
            var usuario = await _usuarioService.Alterar(usuarioPutDTO);

            return Ok(new {message = "Usuário alterado com sucesso!" });
        }

        [HttpGet("filtrar")]
        [Authorize]
        public async Task<ActionResult> SelecionarTodosByFiltro([FromQuery] FiltroUsuario filtroUsuario)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);

            if (!user.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var usuarios = await _usuarioService.SelecionarByFiltroAsync(filtroUsuario.Nome, filtroUsuario.Email,
                filtroUsuario.IsAdmin, filtroUsuario.IsNotAdmin, filtroUsuario.Ativo, filtroUsuario.Inativo, filtroUsuario.PageNumber, filtroUsuario.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(filtroUsuario.PageNumber, usuarios.PageSize,
                usuarios.TotalCount, usuarios.TotalPages));
            return Ok(usuarios);
        }

    }
}
