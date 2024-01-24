using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivrosNovo.API.Models
{
    public class FiltroCliente
    {
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string Cpf { get; set; }

        [StringLength(250, ErrorMessage = "O nome deve ter no máximo 250 caracteres.")]
        public string Nome { get; set; }

        [StringLength(50, ErrorMessage = "A cidade deve ter no máximo 50 caracteres.")]
        public string Cidade { get; set; }

        [StringLength(50, ErrorMessage = "O bairro deve ter no máximo 50 caracteres.")]
        public string Bairro { get; set; }

        [StringLength(11, ErrorMessage = "O telefone celular deve ter no máximo 11 caracteres.")]
        public string TelefoneCelular { get; set; }

        [StringLength(10, ErrorMessage = "O telefone fixo deve ter no máximo 10 caracteres.")]
        public string TelefoneFixo { get; set; }

        [Required(ErrorMessage = "A página é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da página deve ser maior que zero.")]
        public int PageNumber { get; set; }

        [Required(ErrorMessage = "A quantidade de itens por página é obrigatória")]
        [Range(1, 50, ErrorMessage = "O tamanho da página deve estar entre 1 e 50.")]
        public int PageSize { get; set; }


    }
}
