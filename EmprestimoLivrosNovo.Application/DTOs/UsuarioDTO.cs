using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(250, ErrorMessage = "O nome não pode ter mais de 250 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [MaxLength(250, ErrorMessage = "O E-mail não pode ter mais de 200 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A senha deve ter, no máximo, 100 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres.")]
        [NotMapped]
        public string Password { get; set; }
        //[JsonIgnore]
        public bool IsAdmin { get; set; }
    }
}
