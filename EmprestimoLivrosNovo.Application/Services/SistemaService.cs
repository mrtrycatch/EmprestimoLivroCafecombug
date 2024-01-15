using AutoMapper;
using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Application.Interfaces;
using EmprestimoLivrosNovo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.Services
{
    public class SistemaService : ISistemaService
    {
        private readonly ISistemaRepository _repository;
        private readonly IMapper _mapper;

        public SistemaService(ISistemaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QuantidadeItensDTO> SelecionarQtdItens()
        {
            var quantidadeItens = await _repository.SelecionarQtdItens();
            var quantidadeItensDTO = _mapper.Map<QuantidadeItensDTO>(quantidadeItens);
            return quantidadeItensDTO;
        }
    }
}
