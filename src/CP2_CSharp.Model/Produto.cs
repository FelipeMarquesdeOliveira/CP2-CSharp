namespace CP2_CSharp.Model;

/// <summary>
/// Entidade Produto - RM556319 Felipe Marques de Oliveira
/// </summary>
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}
