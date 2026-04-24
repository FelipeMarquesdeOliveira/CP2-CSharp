using System.Globalization;
using CP2_CSharp.Contracts;
using CP2_CSharp.Model;

namespace CP2_CSharp.BLL;

/// <summary>
/// Serviço de produtos com validações
/// RM556319 Felipe Marques de Oliveira | RM556309 Gabriel Barros Cisoto
/// </summary>
public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public List<Produto> ListarTodos()
    {
        return _repository.ListarTodos();
    }

    public List<Produto> BuscarPorNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio");

        return _repository.BuscarPorNome(nome);
    }

    public Produto? BuscarPorId(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id inválido");

        return _repository.BuscarPorId(id);
    }

    public void Cadastrar(Produto produto)
    {
        ValidarProduto(produto);

        if (produto.Preco <= 0)
            throw new ArgumentException("Preço deve ser maior que zero");

        if (produto.Quantidade < 0)
            throw new ArgumentException("Quantidade não pode ser negativa");

        produto.Ativo = true;
        produto.DataCadastro = DateTime.Now;

        _repository.Inserir(produto);
    }

    public void Atualizar(Produto produto)
    {
        if (produto.Id <= 0)
            throw new ArgumentException("Id inválido");

        ValidarProduto(produto);

        if (produto.Preco <= 0)
            throw new ArgumentException("Preço deve ser maior que zero");

        if (produto.Quantidade < 0)
            throw new ArgumentException("Quantidade não pode ser negativa");

        _repository.Atualizar(produto);
    }

    public void EntradaEstoque(int id, int quantidade)
    {
        ValidarId(id);
        ValidarQuantidade(quantidade, "quantidade para entrada");

        var produto = _repository.BuscarPorId(id);
        if (produto == null)
            throw new InvalidOperationException("Produto não encontrado");

        _repository.EntradaEstoque(id, quantidade);
    }

    public void SaidaEstoque(int id, int quantidade)
    {
        ValidarId(id);
        ValidarQuantidade(quantidade, "quantidade para saída");

        var produto = _repository.BuscarPorId(id);
        if (produto == null)
            throw new InvalidOperationException("Produto não encontrado");

        if (produto.Quantidade < quantidade)
            throw new InvalidOperationException("Estoque insuficiente. Quantidade disponível: " + produto.Quantidade);

        _repository.SaidaEstoque(id, quantidade);
    }

    private static void ValidarProduto(Produto produto)
    {
        if (produto == null)
            throw new ArgumentNullException(nameof(produto));

        if (string.IsNullOrWhiteSpace(produto.Nome))
            throw new ArgumentException("Nome é obrigatório");

        if (produto.Nome.Length < 2 || produto.Nome.Length > 100)
            throw new ArgumentException("Nome deve ter entre 2 e 100 caracteres");
    }

    private static void ValidarId(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id inválido");
    }

    private static void ValidarQuantidade(int quantidade, string contexto)
    {
        if (quantidade <= 0)
            throw new ArgumentException($"{char.ToUpper(contexto[0])}{contexto.Substring(1)} deve ser maior que zero");

        if (quantidade > 9999)
            throw new ArgumentException("Quantidade máxima permitida é 9999");
    }

    public static bool ValidarPreco(string? precoTexto, out decimal preco)
    {
        preco = 0;

        if (string.IsNullOrWhiteSpace(precoTexto))
            return false;

        return decimal.TryParse(precoTexto, NumberStyles.Number, CultureInfo.CurrentCulture, out preco)
               || decimal.TryParse(precoTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out preco);
    }

    public static bool ValidarQuantidadeTexto(string? quantidadeTexto, out int quantidade)
    {
        quantidade = 0;

        if (string.IsNullOrWhiteSpace(quantidadeTexto))
            return false;

        return int.TryParse(quantidadeTexto, out quantidade);
    }
}
