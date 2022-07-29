﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sgb.Domain.Entities.CompradorAssociado;

namespace Sgb.Data.EntityMap.CompradorAssociado
{
    public class AssociadoMap : IEntityTypeConfiguration<Associado>
    {

        public void Configure(EntityTypeBuilder<Associado> builder)
        {
            builder.ToTable("Associados");
            builder.HasKey(a => a.CadastroId);
            builder.Property(a => a.Nome).HasMaxLength(150).IsRequired();
            builder.Property(a => a.CPF).HasMaxLength(14).IsRequired();
            builder.Property(a => a.Fazenda).HasMaxLength(180).IsRequired();

            builder.HasOne(a => a.Comprador).WithMany(c => c.Associados)
                .HasForeignKey(a => a.IdComprador).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
