using Microsoft.EntityFrameworkCore;
using Sgb.Domain.Entities.CompradorAssociado;
using Sgb.Domain.Entities.Parceria;
using System.Reflection;

namespace Sgb.Data.Data
{
    public class ContextBvs : DbContext
    {
        public DbSet<Comprador>? Compradores { get; set; }
        public DbSet<Associado>? Associados { get; set; }
        public DbSet<InicioParceria>? InicioParcerias { get; set; }
        public DbSet<AlteracaoSaida>? AlteracaoSaidas { get; set; }

        public ContextBvs(DbContextOptions<ContextBvs> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .AreUnicode(false)
                .HaveMaxLength(500);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseNpgsql("User ID=postgres;Password=007055;Host=localhost;Port=5432;" +
        //            "Database=BVS;Pooling=true;",
        //            //Habilitar consultas divididas globalmente
        //            o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        //    }
        //}
    }
}
