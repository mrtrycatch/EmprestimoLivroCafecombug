using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivrosNovo.API.Models
{
    public class PesquisaTermo
    {
        [Required(ErrorMessage = "O termo de pesquisa é obrigatório")]
        [MaxLength(300, ErrorMessage = "O termo não pode ter mais de 300 caracteres.")]
        public string Termo { get; set; }
        [Required(ErrorMessage = "A página é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da página deve ser maior que zero.")]
        public int PageNumber { get; set; }

        [Required(ErrorMessage = "A quantidade de itens por página é obrigatória")]
        [Range(1, 50, ErrorMessage = "O tamanho da página deve estar entre 1 e 50.")]
        public int PageSize { get; set; }
    }
}
