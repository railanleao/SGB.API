using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sgb.Domain.Entities.Constants;
using Sgb.Domain.Entities.Parceria;

namespace Sgb.Data.EntityMap.Parceria
{
    public class AlteracaoSaídaMap : IEntityTypeConfiguration<AlteracaoSaida>
    {
        public void Configure(EntityTypeBuilder<AlteracaoSaida> builder)
        {
            builder.ToTable("Saidas");

            builder.HasKey(a => a.BoiId);
            builder.Property(a => a.PesoMedioAlterado).HasColumnType("decimal(18,2)");
            builder.Property(a => a.QtdadeSaida).HasColumnType("int").IsRequired();
            builder.Property(a => a.PesoBruto).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(a => a.RendimentoCarcaca).HasColumnType("decimal(18,2)");
            builder.Property(a => a.Arroba).HasColumnType("decimal(18,2)");
            builder.Property(a => a.Saida).HasColumnType("date").IsRequired();

            builder.Property(a => a.Classificacao).HasConversion(a => a.ToString(), a =>
            (Classificacao)Enum.Parse(typeof(Classificacao), a));
            
            builder.Property(a => a.CompraVenda).HasConversion(a => a.ToString(), a =>
            (ModeloDeNegocio)Enum.Parse(typeof(ModeloDeNegocio), a));

            builder.HasOne(a => a.Comprador).WithMany(a => a.AlteracaoSaidas)
                .HasForeignKey(a => a.CompradorId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.Associado).WithMany(a => a.AlteracaoSaidas)
                .HasForeignKey(a => a.AssociadoId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.InicioParceria).WithMany(a => a.AlteracaoSaidas)
                .HasForeignKey(a => a.InicioParceriaId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
