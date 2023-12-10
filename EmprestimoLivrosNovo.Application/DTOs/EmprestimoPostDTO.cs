using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.DTOs
{
    public class EmprestimoPostDTO
    {
        [Required(ErrorMessage = "O cliente é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do cliente é inválido.")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "O Livro é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do livro é inválido.")]
        public int IdLivro { get; set; }
        [Required(ErrorMessage = "A data de entrega é obrigatória")]
        public DateTime DataEntrega { get; set; }
        [JsonIgnore]
        public DateTime DataEmprestimo { get; set; }
        [JsonIgnore]
        public bool Entregue { get; set; }
    }
}
