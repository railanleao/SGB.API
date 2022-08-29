using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Sgb.Data.Data;
using Sgb.Domain.Entities.CompradorAssociado;
using System.Security.Cryptography.X509Certificates;

namespace Sgb.Data.Tests.Database
{
    public class DBInMemory
    {
        private readonly ContextBvs _contextBvs;
        private readonly SqliteConnection _connection;

        public DBInMemory()
        {
            _connection = new SqliteConnection("DataSource=:memory");
            _connection.Open();

            var options = new DbContextOptionsBuilder<ContextBvs>()
                .UseSqlite(_connection)
                .EnableSensitiveDataLogging()
                .Options;

            _contextBvs = new ContextBvs(options);
            InsertFakeData();
        }

        public ContextBvs GetContextBvs() => _contextBvs;

        public void Cleanup() => 
            _connection.Close();

        
        private void InsertFakeData()
        {
            if(_contextBvs.Database.EnsureCreated())
            {
                var idsComprador = new[] { 1, 2, 3 };

                idsComprador.ToList().ForEach(cadastroId =>
                {
                    _contextBvs.Compradores.Add(
                        new Comprador(cadastroId, $"Nome{cadastroId}", $"CPF{cadastroId}")
  
                        );  
                });

                _contextBvs.SaveChanges();
            }
        }
        public void 
    }
}
