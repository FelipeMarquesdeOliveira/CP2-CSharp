using System.Data;
using CP2_CSharp.Config;
using CP2_CSharp.Contracts;
using CP2_CSharp.Model;
using Microsoft.Data.SqlClient;

namespace CP2_CSharp.DAL;

/// <summary>
/// Repositório de produtos usando ADO.NET
/// RM556319 Felipe Marques de Oliveira | RM556309 Gabriel Barros Cisoto
/// </summary>
public class ProdutoRepository : IProdutoRepository
{
    private readonly ConnectionFactory _connectionFactory = new();

    public List<Produto> ListarTodos()
    {
        const string sql = @"
            SELECT Id, Nome, Preco, Quantidade, Ativo, DataCadastro
            FROM dbo.Produto
            WHERE Ativo = 1
            ORDER BY Id DESC";

        var produtos = new List<Produto>();

        using var connection = _connectionFactory.CreateConnection();
        using var command = new SqlCommand(sql, (SqlConnection)connection);

        connection.Open();
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            produtos.Add(MapearProduto(reader));
        }

        return produtos;
    }

    public List<Produto> BuscarPorNome(string nome)
    {
        const string sql = @"
            SELECT Id, Nome, Preco, Quantidade, Ativo, DataCadastro
            FROM dbo.Produto
            WHERE Nome LIKE @Nome AND Ativo = 1
            ORDER BY Nome";

        var produtos = new List<Produto>();

        using var connection = _connectionFactory.CreateConnection();
        using var command = new SqlCommand(sql, (SqlConnection)connection);
        command.Parameters.AddWithValue("@Nome", $"%{nome}%");

        connection.Open();
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            produtos.Add(MapearProduto(reader));
        }

        return produtos;
    }

    public Produto? BuscarPorId(int id)
    {
        const string sql = @"
            SELECT Id, Nome, Preco, Quantidade, Ativo, DataCadastro
            FROM dbo.Produto
            WHERE Id = @Id AND Ativo = 1";

        using var connection = _connectionFactory.CreateConnection();
        using var command = new SqlCommand(sql, (SqlConnection)connection);
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return MapearProduto(reader);
        }

        return null;
    }

    public void Inserir(Produto produto)
    {
        const string sql = @"
            INSERT INTO dbo.Produto (Nome, Preco, Quantidade, Ativo, DataCadastro)
            VALUES (@Nome, @Preco, @Quantidade, @Ativo, @DataCadastro)";

        using var connection = _connectionFactory.CreateConnection();
        using var command = new SqlCommand(sql, (SqlConnection)connection);

        command.Parameters.AddWithValue("@Nome", produto.Nome);
        command.Parameters.AddWithValue("@Preco", produto.Preco);
        command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
        command.Parameters.AddWithValue("@Ativo", produto.Ativo);
        command.Parameters.AddWithValue("@DataCadastro", produto.DataCadastro);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void Atualizar(Produto produto)
    {
        const string sql = @"
            UPDATE dbo.Produto
            SET Nome = @Nome,
                Preco = @Preco,
                Quantidade = @Quantidade,
                Ativo = @Ativo
            WHERE Id = @Id";

        using var connection = _connectionFactory.CreateConnection();
        using var command = new SqlCommand(sql, (SqlConnection)connection);

        command.Parameters.AddWithValue("@Id", produto.Id);
        command.Parameters.AddWithValue("@Nome", produto.Nome);
        command.Parameters.AddWithValue("@Preco", produto.Preco);
        command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
        command.Parameters.AddWithValue("@Ativo", produto.Ativo);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void EntradaEstoque(int id, int quantidade)
    {
        const string sql = @"
            UPDATE dbo.Produto
            SET Quantidade = Quantidade + @Quantidade
            WHERE Id = @Id";

        using var connection = _connectionFactory.CreateConnection();
        using var command = new SqlCommand(sql, (SqlConnection)connection);

        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@Quantidade", quantidade);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void SaidaEstoque(int id, int quantidade)
    {
        const string sql = @"
            UPDATE dbo.Produto
            SET Quantidade = Quantidade - @Quantidade
            WHERE Id = @Id AND Quantidade >= @Quantidade";

        using var connection = _connectionFactory.CreateConnection();
        using var command = new SqlCommand(sql, (SqlConnection)connection);

        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@Quantidade", quantidade);

        connection.Open();
        command.ExecuteNonQuery();
    }

    private static Produto MapearProduto(SqlDataReader reader)
    {
        return new Produto
        {
            Id = Convert.ToInt32(reader["Id"]),
            Nome = reader["Nome"].ToString() ?? string.Empty,
            Preco = Convert.ToDecimal(reader["Preco"]),
            Quantidade = Convert.ToInt32(reader["Quantidade"]),
            Ativo = Convert.ToBoolean(reader["Ativo"]),
            DataCadastro = Convert.ToDateTime(reader["DataCadastro"])
        };
    }
}
