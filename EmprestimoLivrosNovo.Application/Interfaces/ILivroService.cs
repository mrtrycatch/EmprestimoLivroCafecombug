using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.Interfaces
{
    public interface ILivroService
    {
        Task<LivroDTO> Incluir(LivroDTO livroDTO);
        Task<LivroDTO> Alterar(LivroDTO livroDTO);
        Task<LivroDTO> Excluir(int id);
        Task<LivroDTO> SelecionarAsync(int id);
        Task<IEnumerable<LivroDTO>> SelecionarTodosAsync();
    }
}
