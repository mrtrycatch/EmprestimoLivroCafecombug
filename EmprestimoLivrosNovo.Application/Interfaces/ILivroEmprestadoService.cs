using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.Interfaces
{
    public interface ILivroEmprestadoService
    {
        Task<LivroEmprestadoDTO> Incluir(LivroEmprestadoDTO livroEmprestadoDTO);
        Task<IEnumerable<LivroEmprestadoDTO>> IncluirVariosAsync(IEnumerable<LivroEmprestadoDTO> livrosEmprestadosDTO);
        Task<LivroEmprestadoDTO> Excluir(int id);
        Task<LivroEmprestadoDTO> SelecionarAsync(int id);
        Task<IEnumerable<LivroEmprestadoDTO>> SelecionarTodosByEmprestimoAsync(int id);
    }
}
