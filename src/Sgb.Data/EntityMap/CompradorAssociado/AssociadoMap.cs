using Microsoft.EntityFrameworkCore;
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
            builder.Property(a => a.Nome).HasColumnType("varchar").HasMaxLength(150).IsUnicode(false).IsRequired();
            builder.Property(a => a.CPF).HasColumnType("varchar").IsRequired();
            builder.Property(a => a.Fazenda).HasColumnType("varchar").HasMaxLength(180).IsUnicode(false).IsRequired();
            builder.Property(a => a.DataDaParceria).HasColumnType("date").IsUnicode(false).IsRequired();

            builder.HasOne(a => a.Comprador).WithMany(c => c.Associados)
                .HasForeignKey(a => a.CompradorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
