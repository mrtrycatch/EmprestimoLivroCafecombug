using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Interfaces;
using EmprestimoLivrosNovo.Infra.Data.Context;
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
            return await _context.Emprestimo.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Emprestimo>> SelecionarTodosAsync()
        {
            return await _context.Emprestimo.ToListAsync();
        }
    }
}
