using ContatosApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Infra.Data.Mappings
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            //nome da tabela
            builder.ToTable("CONTATO");

            //chave primária
            builder.HasKey(u => u.Id);

            //campos da entidade
            builder.Property(u => u.Id)
                .HasColumnName("ID");

            //campos da entidade
            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            //campos da entidade
            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .IsRequired();

            //índice para campo único
            builder.HasIndex(u => u.Email)
                .IsUnique();

            //campos da entidade
            builder.Property(u => u.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(25)
                .IsRequired();

            //campos da entidade
            builder.Property(u => u.DataHoraCriacao)
                .HasColumnName("DATAHORACRIACAO")
                .IsRequired();
        }
    }
}
