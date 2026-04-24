using System.Data;
using Microsoft.Data.SqlClient;

namespace CP2_CSharp.Config;

/// <summary>
/// Factory de conexão com o banco de dados
/// RM556319 Felipe Marques de Oliveira | RM556309 Gabriel Barros Cisoto
/// </summary>
public class ConnectionFactory
{
    // Banco de dados padronizado: DB_Felipe_RM556319
    private const string ConnectionString =
        "Server=localhost;Database=DB_Felipe_RM556319;Trusted_Connection=True;TrustServerCertificate=True;";

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}
