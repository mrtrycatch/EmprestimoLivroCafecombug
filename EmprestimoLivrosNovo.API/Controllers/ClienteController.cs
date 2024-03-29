﻿using EmprestimoLivrosNovo.API.Extensions;
using EmprestimoLivrosNovo.API.Models;
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
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IUsuarioService _usuarioService;

        public ClienteController(IClienteService clienteService, IUsuarioService usuarioService)
        {
            _clienteService = clienteService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(ClienteDTO clienteDTO)
        {

            var clienteExistente = await _clienteService.SelecionarByCpfAsync(clienteDTO.CliCPF);
            if (clienteExistente != null)
            {
                return BadRequest("Já existe um cliente cadastrado com esse CPF");
            }

            var clienteDTOIncluido = await _clienteService.Incluir(clienteDTO);
            if (clienteDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o cliente.");
            }

            return Ok(new { message = "Cliente incluído com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> Alterar(ClienteDTO clienteDTO)
        {
            var clienteDTOAlterado = await _clienteService.Alterar(clienteDTO);
            if (clienteDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o cliente.");
            }

            return Ok(new { message = "Cliente alterado com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {

            var userId = User.GetId();
            var usuario = await _usuarioService.SelecionarAsync(userId);

            if (!usuario.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para excluir clientes.");
            }

            var clienteDTOExcluido = await _clienteService.Excluir(id);
            if (clienteDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o cliente.");
            }

            return Ok(new { message = "Cliente excluído com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var clienteDTO = await _clienteService.SelecionarAsync(id);
            if (clienteDTO == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(clienteDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos([FromQuery]PaginationParams paginationParams)
        {
            var clientesDTO = await _clienteService.SelecionarTodosAsync
                (paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(clientesDTO.CurrentPage,
                clientesDTO.PageSize, clientesDTO.TotalCount, clientesDTO.TotalPages));

            return Ok(clientesDTO);
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult> SelecionarTodosByFiltro([FromQuery] FiltroCliente filtroCliente)
        {
            var clientesDTO = await _clienteService.SelecionarByFiltroAsync
                (filtroCliente.Cpf, filtroCliente.Nome, filtroCliente.Cidade,
                 filtroCliente.Bairro, filtroCliente.TelefoneCelular,
                 filtroCliente.TelefoneFixo, filtroCliente.PageNumber, filtroCliente.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(clientesDTO.CurrentPage,
                clientesDTO.PageSize, clientesDTO.TotalCount, clientesDTO.TotalPages));

            return Ok(clientesDTO);
        }

        [HttpGet("pesquisar")]
        public async Task<ActionResult> SelecionarByPesquisa([FromQuery] PesquisaTermo pesquisaTermo)
        {
            var clientesDTO = await _clienteService.SelecionarByFiltroAsync
                (pesquisaTermo.Termo, pesquisaTermo.PageNumber, pesquisaTermo.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(clientesDTO.CurrentPage,
                clientesDTO.PageSize, clientesDTO.TotalCount, clientesDTO.TotalPages));

            return Ok(clientesDTO);
        }


    }
}
