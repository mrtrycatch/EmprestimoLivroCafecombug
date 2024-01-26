using System.ComponentModel.DataAnnotations;
using System;

namespace EmprestimoLivrosNovo.API.Models
{
    public class FiltroEmprestimo
    {
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string Cpf { get; set; }

        [StringLength(250, ErrorMessage = "O nome deve ter no máximo 250 caracteres.")]
        public string Nome { get; set; }

        public DateTime? DataEmprestimoInicio { get; set; }
        public DateTime? DataEmprestimoFim { get; set; }

        public DateTime? DataEntregaInicio { get; set; }
        public DateTime? DataEntregaFim { get; set; }

        public bool? Entregue { get; set; }
        public bool? NaoEntregue { get; set; }

        [Required(ErrorMessage = "A página é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da página deve ser maior que zero.")]
        public int PageNumber { get; set; }

        [Required(ErrorMessage = "A quantidade de itens por página é obrigatória")]
        [Range(1, 50, ErrorMessage = "O tamanho da página deve estar entre 1 e 50.")]
        public int PageSize { get; set; }
    }
}
