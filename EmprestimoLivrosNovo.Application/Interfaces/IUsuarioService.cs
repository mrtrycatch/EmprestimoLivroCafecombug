using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO);
        Task<UsuarioPutDTO> Alterar(UsuarioPutDTO usuarioPutDTO);
        Task<UsuarioDTO> Excluir(int id);
        Task<UsuarioDTO> SelecionarAsync(int id);
        Task<PagedList<UsuarioDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<bool> ExisteUsuarioCadastradoAsync();
    }
}
