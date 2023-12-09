using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.DTOs
{
    public class LivroDTO
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "O nome do livro não pode ultrapassar de 50 caracteres.")]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string LivroNome { get; set; }
        [MaxLength(200, ErrorMessage = "O autor do livro não pode ultrapassar de 200 caracteres.")]
        [Required(ErrorMessage = "O campo autor é obrigatório.")]
        public string LivroAutor { get; set; }
        [MaxLength(50, ErrorMessage = "A editora do livro não pode ultrapassar de 50 caracteres.")]
        [Required(ErrorMessage = "O campo editora é obrigatório.")]
        public string LivroEditora { get; set; }
        [Required(ErrorMessage = "O campo Ano de publicação é obrigatório.")]
        public DateTime LivroAnoPublicacao { get; set; }
        [MaxLength(50, ErrorMessage = "O campo edição do livro não pode ultrapassar de 50 caracteres.")]
        [Required(ErrorMessage = "O campo edição é obrigatório.")]
        public string LivroEdicao { get; set; }
    }
}
