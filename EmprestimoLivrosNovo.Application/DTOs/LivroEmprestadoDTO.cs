using EmprestimoLivrosNovo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.DTOs
{
    public class LivroEmprestadoDTO
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Id do empréstimo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int IdEmprestimo { get; set; }
        [Required(ErrorMessage = "O Id do livro é obrigatório")]
        [Range(1, int.MaxValue)]
        public int IdLivro { get; set; }
        public LivroDTO Livro { get; set; }
    }
}
