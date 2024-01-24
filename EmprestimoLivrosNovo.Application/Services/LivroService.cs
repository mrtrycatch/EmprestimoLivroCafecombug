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
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;

        public LivroService(ILivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LivroDTO> Alterar(LivroDTO livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroAlterado = await _repository.Alterar(livro);
            return _mapper.Map<LivroDTO>(livroAlterado);
        }

        public async Task<LivroDTO> Excluir(int id)
        {
            var livroExcluido = await _repository.Excluir(id);
            return _mapper.Map<LivroDTO>(livroExcluido);
        }

        public async Task<LivroDTO> Incluir(LivroDTO livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroIncluido = await _repository.Incluir(livro);
            return _mapper.Map<LivroDTO>(livroIncluido);
        }

        public async Task<LivroDTO> SelecionarAsync(int id)
        {
            var livro = await _repository.SelecionarAsync(id);
            return _mapper.Map<LivroDTO>(livro);
        }

        public async Task<PagedList<LivroDTO>> SelecionarByFiltroAsync(string nome, string autor, string editora, DateTime? anoPublicacao, string edicao, int pageNumber, int pageSize)
        {
            var livros = await _repository.SelecionarByFiltroAsync( nome,  autor,  editora, anoPublicacao, edicao,
                 pageNumber, pageSize);
            var livrosDTO = _mapper.Map<IEnumerable<LivroDTO>>(livros);
            return new PagedList<LivroDTO>(livrosDTO, pageNumber, pageSize, livros.TotalCount);
        }

        public async Task<PagedList<LivroDTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var livros = await _repository.SelecionarTodosAsync(pageNumber, pageSize);
            var livrosDTO = _mapper.Map<IEnumerable<LivroDTO>>(livros);
            return new PagedList<LivroDTO>(livrosDTO, pageNumber, pageSize, livros.TotalCount);
        }
    }
}
