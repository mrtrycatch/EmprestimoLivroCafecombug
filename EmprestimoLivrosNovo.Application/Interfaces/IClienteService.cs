using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO> Incluir(ClienteDTO clienteDTO);
        Task<ClienteDTO> Alterar(ClienteDTO clienteDTO);
        Task<ClienteDTO> Excluir(int id);
        Task<ClienteDTO> SelecionarAsync(int id);
        Task<ClienteDTO> SelecionarByCpfAsync(string cpf);
        Task<PagedList<ClienteDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<PagedList<ClienteDTO>> SelecionarByFiltroAsync(string cpf, string nome,
            string cidade, string bairro, string telefoneCelular, string telefoneFixo,
            int pageNumber, int pageSize);
    }
}
