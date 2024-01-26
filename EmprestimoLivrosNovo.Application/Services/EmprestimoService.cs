using AutoMapper;
using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Application.Interfaces;
using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Interfaces;
using EmprestimoLivrosNovo.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IMapper _mapper;

        public EmprestimoService(IEmprestimoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmprestimoDTO> Alterar(EmprestimoDTO emprestimoDTO)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoDTO);
            var emprestimoAlterado = await _repository.Alterar(emprestimo);
            return _mapper.Map<EmprestimoDTO>(emprestimoAlterado);
        }

        public async Task<EmprestimoDTO> Excluir(int id)
        {
            var emprestimoExcluido = await _repository.Excluir(id);
            return _mapper.Map<EmprestimoDTO>(emprestimoExcluido);
        }

        public async Task<EmprestimoDTO> Incluir(EmprestimoPostDTO emprestimoPostDTO)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoPostDTO);
            var emprestimoIncluido = await _repository.Incluir(emprestimo);
            return _mapper.Map<EmprestimoDTO>(emprestimoIncluido);
        }

        public async Task<EmprestimoDTO> SelecionarAsync(int id)
        {
            var emprestimo = await _repository.SelecionarAsync(id);
            return _mapper.Map<EmprestimoDTO>(emprestimo);
        }

        public async Task<PagedList<EmprestimoDTO>> SelecionarByFiltroAsync(string cpf, string nome, DateTime? dataEmprestimoInicio, DateTime? dataEmprestimoFim, DateTime? dataEntregaInicio, DateTime? dataEntregaFim, bool? entregue, bool? naoEntregue, int pageNumber, int pageSize)
        {
            var emprestimos = await _repository.SelecionarByFiltroAsync( cpf, nome,
                dataEmprestimoInicio, dataEmprestimoFim,dataEntregaInicio,dataEntregaFim,
                entregue, naoEntregue, pageNumber,  pageSize);
            
            var emprestimosDTO = _mapper.Map<IEnumerable<EmprestimoDTO>>(emprestimos);
            return new PagedList<EmprestimoDTO>(emprestimosDTO, pageNumber, pageSize, emprestimos.TotalCount);
        }

        public async Task<PagedList<EmprestimoDTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var emprestimos = await _repository.SelecionarTodosAsync(pageNumber, pageSize);
            var emprestimosDTO = _mapper.Map<IEnumerable<EmprestimoDTO>>(emprestimos);
            return new PagedList<EmprestimoDTO>(emprestimosDTO, pageNumber, pageSize, emprestimos.TotalCount);
        }

        public async Task<bool> VerificaDisponibilidadeAsync(int[] idsLivros)
        {
            return await _repository.VerificaDisponibilidadeAsync(idsLivros);
        }
    }
}
