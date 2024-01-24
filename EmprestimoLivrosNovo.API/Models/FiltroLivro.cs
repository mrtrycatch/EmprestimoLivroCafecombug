using System.ComponentModel.DataAnnotations;
using System;

namespace EmprestimoLivrosNovo.API.Models
{
    public class FiltroLivro
    {
        public string Nome { get; set; }
        [MaxLength(200, ErrorMessage = "O autor do livro não pode ultrapassar de 200 caracteres.")]
        public string Autor { get; set; }
        [MaxLength(50, ErrorMessage = "A editora do livro não pode ultrapassar de 50 caracteres.")]
        public string Editora { get; set; }
        public DateTime? AnoPublicacao { get; set; }
        [MaxLength(50, ErrorMessage = "O campo edição do livro não pode ultrapassar de 50 caracteres.")]
        public string Edicao { get; set; }
        [Required(ErrorMessage = "A página é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da página deve ser maior que zero.")]
        public int PageNumber { get; set; }

        [Required(ErrorMessage = "A quantidade de itens por página é obrigatória")]
        [Range(1, 50, ErrorMessage = "O tamanho da página deve estar entre 1 e 100.")]
        public int PageSize { get; set; }
    }
}
