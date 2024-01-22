using EmprestimoLivrosNovo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Domain.Entities
{
    public class LivroEmprestado
    {
        public int Id { get; private set; }
        public int IdEmprestimo { get; private set; }
        public int IdLivro { get; private set; }
        public Livro Livro { get; set; }
        public Emprestimo Emprestimo { get; set; }

        public LivroEmprestado(int id, int idEmprestimo, int idLivro)
        {
            DomainExceptionValidation.When(id < 0, "Id do livro deve ser positivo.");
            Id = id;
            ValidateDomain(idEmprestimo, idLivro);
        }

        public LivroEmprestado(int idEmprestimo, int idLivro)
        {
            ValidateDomain(idEmprestimo, idLivro);
        }

        public void Update(int idEmprestimo, int idLivro)
        {
            ValidateDomain(idEmprestimo, idLivro);
        }

        private void ValidateDomain(int idEmprestimo, int idLivro)
        {
            DomainExceptionValidation.When(idEmprestimo <= 0, "Id do empréstimo é inválido.");
            DomainExceptionValidation.When(idLivro < 0, "Id do livro é inválido.");
            IdEmprestimo = idEmprestimo;
            IdLivro = idLivro;
        }
    }
}
