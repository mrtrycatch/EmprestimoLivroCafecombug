using EmprestimoLivrosNovo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<Livro> Incluir(Livro livro);
        Task<Livro> Alterar(Livro livro);
        Task<Livro> Excluir(int id);
        Task<Livro> SelecionarAsync(int id);
        Task<IEnumerable<Livro>> SelecionarTodosAsync();
    }
}
