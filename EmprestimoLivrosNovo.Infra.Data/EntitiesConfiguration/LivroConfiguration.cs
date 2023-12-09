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
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LivroNome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LivroAutor).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LivroEditora).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LivroEdicao).HasMaxLength(50).IsRequired();
        }
    }
}
