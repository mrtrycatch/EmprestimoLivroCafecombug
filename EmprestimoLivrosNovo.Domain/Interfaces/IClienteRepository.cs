using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> Incluir(Cliente cliente);
        Task<Cliente> Alterar(Cliente cliente);
        Task<Cliente> Excluir(int id);
        Task<Cliente> SelecionarAsync(int id);
        Task<Cliente> SelecionarByCPFAsync(string cpf);
        Task<PagedList<Cliente>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<PagedList<Cliente>> SelecionarByFiltroAsync(string cpf, string nome,
            string cidade, string bairro, string telefoneCelular, string telefoneFixo,
            int pageNumber, int pageSize);
    }
}
