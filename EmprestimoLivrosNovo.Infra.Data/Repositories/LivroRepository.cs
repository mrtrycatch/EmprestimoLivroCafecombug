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
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationDbContext _context;

        public LivroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Livro> Alterar(Livro livro)
        {
            _context.Livro.Update(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<Livro> Excluir(int id)
        {
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
                await _context.SaveChangesAsync();
                return livro;
            }

            return null;
        }

        public async Task<Livro> Incluir(Livro livro)
        {
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<Livro> SelecionarAsync(int id)
        {
            return await _context.Livro.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedList<Livro>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.Livro.AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }
    }
}
