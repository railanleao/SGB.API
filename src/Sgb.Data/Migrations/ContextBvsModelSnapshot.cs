﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sgb.Data.Data;

#nullable disable

namespace Sgb.Data.Migrations
{
    [DbContext(typeof(ContextBvs))]
    partial class ContextBvsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sgb.Domain.Entities.CompradorAssociado.Associado", b =>
                {
                    b.Property<Guid>("CadastroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar");

                    b.Property<Guid>("CompradorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataDaParceria")
                        .IsUnicode(false)
                        .HasColumnType("date");

                    b.Property<string>("Fazenda")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar");

                    b.HasKey("CadastroId");

                    b.HasIndex("CompradorId");

                    b.ToTable("Associados", (string)null);
                });

            modelBuilder.Entity("Sgb.Domain.Entities.CompradorAssociado.Comprador", b =>
                {
                    b.Property<Guid>("CadastroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar");

                    b.HasKey("CadastroId");

                    b.ToTable("Compradores", (string)null);
                });

            modelBuilder.Entity("Sgb.Domain.Entities.Parceria.AlteracaoSaida", b =>
                {
                    b.Property<Guid>("BoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Arroba")
                        .HasColumnType("numeric(18,2)");

                    b.Property<Guid>("AssociadoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Classificacao")
                        .HasColumnType("text");

                    b.Property<string>("CompraVenda")
                        .HasColumnType("text");

                    b.Property<Guid>("CompradorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InicioParceriaId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("PesoBruto")
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal?>("PesoMedioAlterado")
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("QtdadeSaida")
                        .HasColumnType("int");

                    b.Property<decimal>("RendimentoCarcaca")
                        .HasColumnType("numeric(18,2)");

                    b.Property<DateTime>("Saida")
                        .HasColumnType("date");

                    b.HasKey("BoiId");

                    b.HasIndex("AssociadoId");

                    b.HasIndex("CompradorId");

                    b.HasIndex("InicioParceriaId");

                    b.ToTable("Saidas", (string)null);
                });

            modelBuilder.Entity("Sgb.Domain.Entities.Parceria.InicioParceria", b =>
                {
                    b.Property<Guid>("BoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Arroba")
                        .IsUnicode(false)
                        .HasColumnType("numeric(18,2)");

                    b.Property<Guid>("AssociadoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Classificacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CompraVenda")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CompradorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataInicioParceria")
                        .HasColumnType("date");

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar");

                    b.Property<decimal>("PesoBruto")
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("QtdadeEntrada")
                        .HasColumnType("int");

                    b.Property<decimal>("RendimentoCarcaca")
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("BoiId");

                    b.HasIndex("AssociadoId");

                    b.HasIndex("CompradorId");

                    b.ToTable("Parcerias", (string)null);
                });

            modelBuilder.Entity("Sgb.Domain.Entities.CompradorAssociado.Associado", b =>
                {
                    b.HasOne("Sgb.Domain.Entities.CompradorAssociado.Comprador", "Comprador")
                        .WithMany("Associados")
                        .HasForeignKey("CompradorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Comprador");
                });

            modelBuilder.Entity("Sgb.Domain.Entities.Parceria.AlteracaoSaida", b =>
                {
                    b.HasOne("Sgb.Domain.Entities.CompradorAssociado.Associado", "Associado")
                        .WithMany("AlteracaoSaidas")
                        .HasForeignKey("AssociadoId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Sgb.Domain.Entities.CompradorAssociado.Comprador", "Comprador")
                        .WithMany("AlteracaoSaidas")
                        .HasForeignKey("CompradorId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Sgb.Domain.Entities.Parceria.InicioParceria", "InicioParceria")
                        .WithMany("AlteracaoSaidas")
                        .HasForeignKey("InicioParceriaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Associado");

                    b.Navigation("Comprador");

                    b.Navigation("InicioParceria");
                });

            modelBuilder.Entity("Sgb.Domain.Entities.Parceria.InicioParceria", b =>
                {
                    b.HasOne("Sgb.Domain.Entities.CompradorAssociado.Associado", "Associado")
                        .WithMany("InicioParcerias")
                        .HasForeignKey("AssociadoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Sgb.Domain.Entities.CompradorAssociado.Comprador", "Comprador")
                        .WithMany("InicioParcerias")
                        .HasForeignKey("CompradorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Associado");

                    b.Navigation("Comprador");
                });

            modelBuilder.Entity("Sgb.Domain.Entities.CompradorAssociado.Associado", b =>
                {
                    b.Navigation("AlteracaoSaidas");

                    b.Navigation("InicioParcerias");
                });

            modelBuilder.Entity("Sgb.Domain.Entities.CompradorAssociado.Comprador", b =>
                {
                    b.Navigation("AlteracaoSaidas");

                    b.Navigation("Associados");

                    b.Navigation("InicioParcerias");
                });

            modelBuilder.Entity("Sgb.Domain.Entities.Parceria.InicioParceria", b =>
                {
                    b.Navigation("AlteracaoSaidas");
                });
#pragma warning restore 612, 618
        }
    }
}
