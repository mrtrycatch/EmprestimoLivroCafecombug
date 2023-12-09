using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.DTOs
{
    public class ClienteDTO
    {
        [IgnoreDataMember]
        public int Id { get; set; }
        [Required]
        [StringLength(11,MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        public string CliCPF { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "O Nome deve ter 200 caracteres")]
        public string CliNome { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O Endereço deve ter 50 caracteres")]
        public string CliEndereco { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "A Cidade deve ter 50 caracteres")]
        public string CliCidade { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O Bairro deve ter 50 caracteres")]
        public string CliBairro { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O número deve ter 50 caracteres")]
        public string CliNumero { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "O número de Telefone celular deve ter 11 caracteres")]
        public string CliTelefoneCelular { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "O número de Telefone fixo deve ter 10 caracteres")]
        public string CliTelefoneFixo { get; set; }
    }
}
