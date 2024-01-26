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
            return await _context.Emprestimo.Include(x => x.Cliente).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedList<Emprestimo>> SelecionarByFiltroAsync(string cpf, string nome, DateTime? dataEmprestimoInicio, DateTime? dataEmprestimoFim, DateTime? dataEntregaInicio, DateTime? dataEntregaFim, bool? entregue, bool? naoEntregue, int pageNumber, int pageSize)
        {
            var query = _context.Emprestimo.Include(x => x.Cliente).AsQueryable();

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(x => x.Cliente.CliCPF.Equals(cpf));
            }

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => x.Cliente.CliNome.ToLower().Equals(nome.ToLower())
                                     || x.Cliente.CliNome.ToLower().Contains(nome.ToLower()));
            }

            if (dataEmprestimoInicio.HasValue)
            {
                query = query.Where(x => dataEmprestimoInicio.Value <= x.DataEmprestimo);
            }

            if (dataEmprestimoFim.HasValue)
            {
                query = query.Where(x => x.DataEmprestimo <= dataEmprestimoFim.Value);
            }

            if (dataEntregaInicio.HasValue)
            {
                query = query.Where(x => dataEntregaInicio.Value <= x.DataEntrega);
            }

            if (dataEntregaFim.HasValue)
            {
                query = query.Where(x => x.DataEntrega <= dataEntregaFim.Value);
            }

            if (entregue.HasValue && entregue == true)
            {
                query = query.Where(x => x.Entregue == true);
            }

            if (naoEntregue.HasValue && naoEntregue == true)
            {
                query = query.Where(x => x.Entregue == false);
            }

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<PagedList<Emprestimo>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.Emprestimo.Include(x => x.Cliente).AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<bool> VerificaDisponibilidadeAsync(int[] idsLivros)
        {
            var existeEmprestimo = await _context.Emprestimo
                .Where(x => x.LivrosEmprestados.Any(le => idsLivros.Contains(le.IdLivro)) && !x.Entregue)
                .AnyAsync();
            return !existeEmprestimo;
        }
    }
}
