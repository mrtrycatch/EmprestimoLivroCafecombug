using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Interfaces;
using EmprestimoLivrosNovo.Domain.Pagination;
using EmprestimoLivrosNovo.Infra.Data.Context;
using EmprestimoLivrosNovo.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Infra.Data.Repositories
{
    public class LivroEmprestadoRepository : ILivroEmprestadoRepository
    {
        private readonly ApplicationDbContext _context;

        public LivroEmprestadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LivroEmprestado> Alterar(LivroEmprestado livroEmprestado)
        {
            _context.LivroEmprestado.Update(livroEmprestado);
            await _context.SaveChangesAsync();
            return livroEmprestado;
        }

        public async Task<LivroEmprestado> Excluir(int id)
        {
            var livroEmprestado = await _context.LivroEmprestado.FindAsync(id);
            if (livroEmprestado != null)
            {
                _context.LivroEmprestado.Remove(livroEmprestado);
                await _context.SaveChangesAsync();
                return livroEmprestado;
            }

            return null;
        }

        public async Task<LivroEmprestado> Incluir(LivroEmprestado livroEmprestado)
        {
            _context.LivroEmprestado.Add(livroEmprestado);
            await _context.SaveChangesAsync();
            return livroEmprestado;
        }

        public async Task<IEnumerable<LivroEmprestado>> IncluirVariosAsync(IEnumerable<LivroEmprestado> livrosEmprestados)
        {
            var idsLivrosValidos = await _context.Livro
            .Where(l => livrosEmprestados.Select(le => le.IdLivro).Contains(l.Id))
            .Select(l => l.Id)
            .ToListAsync();

            var livrosEmprestadosValidos = livrosEmprestados
                .Where(le => idsLivrosValidos.Contains(le.IdLivro))
                .ToList();

            _context.LivroEmprestado.AddRange(livrosEmprestadosValidos);
            await _context.SaveChangesAsync();
            return livrosEmprestados;
        }

        public async Task<LivroEmprestado> SelecionarAsync(int id)
        {
            return await _context.LivroEmprestado.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<LivroEmprestado>> SelecionarTodosByEmprestimoAsync(int id)
        {
            return await _context.LivroEmprestado.Where(x => x.IdEmprestimo == id).Include(x => x.Livro).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<IEnumerable<LivroEmprestado>> SubstituirTodosAsync(List<LivroEmprestado> livrosEmprestados)
        {
            if (livrosEmprestados.Count == 0)
            {
                return new List<LivroEmprestado>();
            }

            var idsLivrosValidos = await _context.Livro
            .Where(l => livrosEmprestados.Select(le => le.IdLivro).Contains(l.Id))
            .Select(l => l.Id)
            .ToListAsync();

            var livrosEmprestadosValidos = livrosEmprestados
                .Where(le => idsLivrosValidos.Contains(le.IdLivro))
                .ToList();

            var livrosEmprestadosByEmprestimo = _context.LivroEmprestado.Where(x => x.IdEmprestimo == livrosEmprestados[0].IdEmprestimo);
            _context.LivroEmprestado.RemoveRange(livrosEmprestadosByEmprestimo);

            _context.LivroEmprestado.AddRange(livrosEmprestadosValidos);
            await _context.SaveChangesAsync();
            return livrosEmprestados;
        }
    }
}
