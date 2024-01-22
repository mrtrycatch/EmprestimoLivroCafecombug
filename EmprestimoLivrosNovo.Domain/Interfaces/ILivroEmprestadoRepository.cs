using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Domain.Interfaces
{
    public interface ILivroEmprestadoRepository
    {
        Task<LivroEmprestado> Incluir(LivroEmprestado livroEmprestado);
        Task<IEnumerable<LivroEmprestado>> IncluirVariosAsync(IEnumerable<LivroEmprestado> livrosEmprestados);
        Task<LivroEmprestado> Excluir(int id);
        Task<LivroEmprestado> SelecionarAsync(int id);
        Task<IEnumerable<LivroEmprestado>> SelecionarTodosByEmprestimoAsync(int id);
    }
}
