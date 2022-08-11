using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sgb.Domain.Entities.Parceria;

namespace Sgb.Data.EntityMap.Parceria
{
    public class InicioParceriaMap : IEntityTypeConfiguration<InicioParceria>
    {
        public void Configure(EntityTypeBuilder<InicioParceria> builder)
        {
            builder.ToTable("Parcerias");
            builder.HasKey(i => i.BoiId);
            builder.Property(i => i.Lote).HasColumnType("varchar").HasMaxLength(10).IsUnicode(false);
            builder.Property(i => i.QtdadeEntrada).HasColumnType("int").IsRequired();
            builder.Property(i => i.DataInicioParceria).HasColumnType("date").IsRequired();
            builder.Property(i => i.PesoBruto).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(i => i.RendimentoCarcaca).HasColumnType("decimal(18,2)");
            builder.Property(i => i.Origem).HasColumnType("varchar").HasMaxLength(50).IsUnicode(false).IsRequired();
            //builder.Property(i => i.PorcentoMes).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(i => i.Arroba).HasColumnType("decimal(18,2)").IsUnicode(false).IsRequired();
            builder.Property(i => i.Valor).HasColumnType("decimal(18,2)").IsRequired();
            

            builder.Property(i => i.Classificacao).HasConversion(i => i.ToString(), i =>
            (Classificacao)Enum.Parse(typeof(Classificacao), i)).IsRequired();

            builder.Property(i => i.CompraVenda).HasConversion(i => i.ToString(), i =>
            (CompraVenda)Enum.Parse(typeof(CompraVenda), i)).IsRequired();

            builder.HasOne(i => i.Comprador).WithMany(i => i.InicioParcerias)
                .HasForeignKey(i => i.CompradorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(i => i.Associado).WithMany(i => i.InicioParcerias)
                .HasForeignKey(i => i.AssociadoId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(i => i.AlteracaoSaidas).WithOne(i => i.InicioParceria).OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(c => c.AlteracaoSaidas).AutoInclude();
        }
    }
}
