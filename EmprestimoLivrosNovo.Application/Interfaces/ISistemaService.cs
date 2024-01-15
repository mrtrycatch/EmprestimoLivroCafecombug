using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Domain.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.Interfaces
{
    public interface ISistemaService
    {
        Task<QuantidadeItensDTO> SelecionarQtdItens();
    }
}
