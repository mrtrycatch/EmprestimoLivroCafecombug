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
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Alterar(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Excluir(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }

            return null;
        }

        public async Task<Cliente> Incluir(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> SelecionarAsync(int id)
        {
            return await _context.Cliente.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> SelecionarByCPFAsync(string cpf)
        {
            return await _context.Cliente.Where(x => x.CliCPF.Equals(cpf)).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Cliente>> SelecionarByFiltroAsync(string cpf, string nome, string cidade, string bairro, string telefoneCelular, string telefoneFixo, int pageNumber, int pageSize)
        {
            var query = _context.Cliente.AsQueryable();

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(x => x.CliCPF.Equals(cpf));
            }

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => x.CliNome.ToLower().Equals(nome.ToLower())
                || x.CliNome.ToLower().Contains(nome.ToLower()));
            }

            if (!string.IsNullOrEmpty(cidade))
            {
                query = query.Where(x => x.CliCidade.ToLower().Equals(cidade.ToLower())
                || x.CliCidade.ToLower().Contains(cidade.ToLower()));
            }

            if (!string.IsNullOrEmpty(bairro))
            {
                query = query.Where(x => x.CliBairro.ToLower().Equals(bairro.ToLower())
                || x.CliBairro.ToLower().Contains(bairro.ToLower()));
            }

            if (!string.IsNullOrEmpty(telefoneCelular))
            {
                query = query.Where(x => x.CliTelefoneCelular.Equals(telefoneCelular));
            }

            if (!string.IsNullOrEmpty(telefoneFixo))
            {
                query = query.Where(x => x.CliTelefoneFixo.Equals(telefoneFixo));
            }

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<PagedList<Cliente>> SelecionarByFiltroAsync(string termo, int pageNumber, int pageSize)
        {
            var query = _context.Cliente.AsQueryable();

            if (!string.IsNullOrEmpty(termo))
            {
                termo = termo.ToLower();

                query = query.Where(x =>
                    x.CliNome.ToLower().Contains(termo) ||
                    x.CliCPF.Contains(termo) ||
                    x.CliCidade.ToLower().Contains(termo) ||
                    x.CliBairro.ToLower().Contains(termo) ||
                    x.CliTelefoneCelular.Contains(termo) ||
                    x.CliTelefoneFixo.Contains(termo)
                );
            }

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<PagedList<Cliente>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.Cliente.AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }
    }
}