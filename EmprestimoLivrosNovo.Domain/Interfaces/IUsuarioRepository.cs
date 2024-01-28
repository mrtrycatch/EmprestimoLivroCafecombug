using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Incluir(Usuario usuario);
        Task<Usuario> Alterar(Usuario usuario);
        Task<Usuario> Excluir(int id);
        Task<Usuario> SelecionarAsync(int id);
        Task<PagedList<Usuario>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<bool> ExisteUsuarioCadastradoAsync();
        Task<PagedList<Usuario>> SelecionarByFiltroAsync(
        string nome, string email, bool? isAdmin, bool? isNotAdmin, bool? ativo, bool? inativo, int pageNumber, int pageSize);
    }
}
