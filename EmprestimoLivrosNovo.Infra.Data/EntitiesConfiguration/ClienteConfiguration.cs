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
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CliCPF).HasMaxLength(11).IsRequired();
            builder.Property(x => x.CliNome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CliEndereco).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CliCidade).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CliBairro).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CliNumero).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CliTelefoneCelular).HasMaxLength(11).IsRequired();
            builder.Property(x => x.CliTelefoneFixo).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Excluido).IsRequired();
        }
    }
}
