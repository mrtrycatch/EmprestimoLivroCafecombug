using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task<Emprestimo> Incluir(Emprestimo emprestimo);
        Task<Emprestimo> Alterar(Emprestimo emprestimo);
        Task<Emprestimo> Excluir(int id);
        Task<Emprestimo> SelecionarAsync(int id);
        Task<PagedList<Emprestimo>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<bool> VerificaDisponibilidadeAsync(int[] idsLivros);
    }
}
