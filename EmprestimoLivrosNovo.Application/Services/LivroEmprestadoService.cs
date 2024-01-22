using AutoMapper;
using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Application.Interfaces;
using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.Services
{
    public class LivroEmprestadoService : ILivroEmprestadoService
    {
        private readonly ILivroEmprestadoRepository _repository;
        private readonly IMapper _mapper;

        public LivroEmprestadoService(ILivroEmprestadoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LivroEmprestadoDTO> Excluir(int id)
        {
            var livroEmprestado = await _repository.Excluir(id);
            return _mapper.Map<LivroEmprestadoDTO>(livroEmprestado);
        }

        public async Task<LivroEmprestadoDTO> Incluir(LivroEmprestadoDTO livroEmprestadoDTO)
        {
            var livroEmprestado = _mapper.Map<LivroEmprestado>(livroEmprestadoDTO);
            var livroEmprestadoIncluido = await _repository.Incluir(livroEmprestado);
            return _mapper.Map<LivroEmprestadoDTO>(livroEmprestadoIncluido);
        }

        public async Task<IEnumerable<LivroEmprestadoDTO>> IncluirVariosAsync(IEnumerable<LivroEmprestadoDTO> livrosEmprestadosDTO)
        {
            var livrosEmprestados = _mapper.Map<IEnumerable<LivroEmprestado>>(livrosEmprestadosDTO);
            var livrosEmprestadosIncluidos = await _repository.IncluirVariosAsync(livrosEmprestados);
            return _mapper.Map<IEnumerable<LivroEmprestadoDTO>>(livrosEmprestadosIncluidos);
        }

        public async Task<LivroEmprestadoDTO> SelecionarAsync(int id)
        {
            var livrosEmprestados = await _repository.SelecionarAsync(id);
            return _mapper.Map<LivroEmprestadoDTO>(livrosEmprestados);
        }

        public async Task<IEnumerable<LivroEmprestadoDTO>> SelecionarTodosByEmprestimoAsync(int id)
        {
            var livroEmprestados = await _repository.SelecionarTodosByEmprestimoAsync(id);
            return _mapper.Map<IEnumerable<LivroEmprestadoDTO>>(livroEmprestados);
        }
    }
}
