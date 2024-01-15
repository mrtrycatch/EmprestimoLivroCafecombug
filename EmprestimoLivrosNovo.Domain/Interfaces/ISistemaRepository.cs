using EmprestimoLivrosNovo.Domain.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Domain.Interfaces
{
    public interface ISistemaRepository
    {
        Task<QuantidadeItens> SelecionarQtdItens();
    }
}
