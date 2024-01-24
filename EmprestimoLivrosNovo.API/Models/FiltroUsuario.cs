using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivrosNovo.API.Models
{
    public class FiltroUsuario
    {
        [MaxLength(250, ErrorMessage = "O nome não pode ter mais de 250 caracteres")]
        public string Nome { get; set; }
        [MaxLength(250, ErrorMessage = "O E-mail não pode ter mais de 200 caracteres")]
        public string Email { get; set; }
        public bool? IsAdmin { get; set; }
        [Required(ErrorMessage = "A página é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da página deve ser maior que zero.")]
        public int PageNumber { get; set; }

        [Required(ErrorMessage = "A quantidade de itens por página é obrigatória")]
        [Range(1, 50, ErrorMessage = "O tamanho da página deve estar entre 1 e 50.")]
        public int PageSize { get; set; }
    }
}
