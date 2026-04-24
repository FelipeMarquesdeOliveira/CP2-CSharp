using CP2_CSharp.Model;

namespace CP2_CSharp.Contracts;

/// <summary>
/// Interface do serviço de produtos
/// RM556319 Felipe Marques de Oliveira | RM556309 Gabriel Barros Cisoto
/// </summary>
public interface IProdutoService
{
    List<Produto> ListarTodos();
    List<Produto> BuscarPorNome(string nome);
    Produto? BuscarPorId(int id);
    void Cadastrar(Produto produto);
    void Atualizar(Produto produto);
    void EntradaEstoque(int id, int quantidade);
    void SaidaEstoque(int id, int quantidade);
}
