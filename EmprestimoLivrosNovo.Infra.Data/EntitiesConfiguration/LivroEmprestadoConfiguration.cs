using EmprestimoLivrosNovo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Infra.Data.EntitiesConfiguration
{
    internal class LivroEmprestadoConfiguration : IEntityTypeConfiguration<LivroEmprestado>
    {
        public void Configure(EntityTypeBuilder<LivroEmprestado> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdLivro).IsRequired();
            builder.Property(x => x.IdEmprestimo).IsRequired();
            builder.HasOne(x => x.Livro).WithMany(x => x.LivrosEmprestados)
                .HasForeignKey(x => x.IdLivro).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Emprestimo).WithMany(x => x.LivrosEmprestados)
                .HasForeignKey(x => x.IdEmprestimo).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
