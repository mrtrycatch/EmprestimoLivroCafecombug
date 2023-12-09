using EmprestimoLivrosNovo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        public Usuario(int id, string nome, string email)
        {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            Id = id;
            ValidateDomain(nome, email);
            
        }

        public Usuario(string nome, string email)
        {
            ValidateDomain(nome, email);
        }

        public void SetAdmin(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash= passwordHash;
            PasswordSalt= passwordSalt;
        }

        private void ValidateDomain(string nome, string email)
        {
            DomainExceptionValidation.When(nome == null, "O nome é obrigatório.");
            DomainExceptionValidation.When(email == null, "O E-mail é obrigatório.");
            DomainExceptionValidation.When(nome.Length > 250, "O nome não pode ultrapassar de 250 caracteres.");
            DomainExceptionValidation.When(email.Length > 200, "O nome não pode ultrapassar de 200 caracteres.");
            Nome = nome;
            Email = email;
            IsAdmin = false;
        }

    }
}
