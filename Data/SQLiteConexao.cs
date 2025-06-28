using Microsoft.Data.Sqlite;
using Dapper;
using System.Data;
using ApiAuth.Models;

namespace ApiAuth.Data
{
    public class SQLiteConexao
    {
        private readonly string _conexao = "Data Source=C:\\scriptscsharp\\Bancos\\Base.db";

        private IDbConnection CriarConexao() => new SqliteConnection(_conexao);

        public void Inicializar()
        {
            using var conexao = CriarConexao();
            conexao.Open();

            var sql = conexao.CreateCommand();
            sql.CommandText = @"CREATE TABLE IF NOT EXISTS Usuarios (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Email TEXT NOT NULL
                        Senha TEXT NOT NULL
                        Role TEXT NOT NULL
                    )";
            sql.ExecuteNonQuery();
        }

        public async Task<T> ExecutarConsulta<T>(string consulta)
        {
            using var conexao = CriarConexao();
            conexao.Open();
            
            var resultado = await conexao.QueryFirstOrDefaultAsync<T>(consulta);

            return resultado;
        }

    }
}
