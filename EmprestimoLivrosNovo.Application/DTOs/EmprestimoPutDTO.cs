using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.DTOs
{
    public class EmprestimoPutDTO
    {
        [Required(ErrorMessage = "O indentificador do empréstimo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do empréstimo é inválido.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O indentificador do Cliente é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do Cliente é inválido.")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "A data de entrega é obrigatório.")]
        public DateTime DataEntrega { get; set; }
        [Required(ErrorMessage = "O estado da entrega é obrigatório.")]
        public bool Entregue { get; set; }
        [NotMapped]
        public int[] idsLivros { get; set; }
    }
}
