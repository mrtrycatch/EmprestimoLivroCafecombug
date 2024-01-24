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
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(250).IsRequired();
            builder.Property(x => x.IsAdmin).IsRequired();
            builder.Property(x => x.Ativo).HasDefaultValue(true).IsRequired();
        }
    }
}
