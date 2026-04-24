namespace CP2_CSharp.Models;

public class Medico
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Crm { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
}
