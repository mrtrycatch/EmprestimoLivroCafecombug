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
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmprestimoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Emprestimo> Alterar(Emprestimo emprestimo)
        {
            _context.Emprestimo.Update(emprestimo);
            await _context.SaveChangesAsync();
            return emprestimo;
        }

        public async Task<Emprestimo> Excluir(int id)
        {
            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo != null)
            {
                _context.Emprestimo.Remove(emprestimo);
                await _context.SaveChangesAsync();
                return emprestimo;
            }

            return null;
        }

        public async Task<Emprestimo> Incluir(Emprestimo emprestimo)
        {
            _context.Emprestimo.Add(emprestimo);
            await _context.SaveChangesAsync();
            return emprestimo;
        }

        public async Task<Emprestimo> SelecionarAsync(int id)
        {
            return await _context.Emprestimo.Include(x => x.Cliente).Include(x => x.Livro).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedList<Emprestimo>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.Emprestimo.Include(x => x.Cliente).Include(x => x.Livro).AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<bool> VerificaDisponibilidadeAsync(int idLivro)
        {
            var existeEmprestimo = await _context.Emprestimo.
                Where(x => x.IdLivro == idLivro && x.Entregue == false).AnyAsync();

            return !existeEmprestimo;
        }
    }
}
