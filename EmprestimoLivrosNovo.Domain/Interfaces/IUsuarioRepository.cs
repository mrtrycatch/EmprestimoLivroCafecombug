using EmprestimoLivrosNovo.Domain.Entities;
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
        Task<IEnumerable<Usuario>> SelecionarTodosAsync();
        Task<bool> ExisteUsuarioCadastradoAsync();
    }
}
