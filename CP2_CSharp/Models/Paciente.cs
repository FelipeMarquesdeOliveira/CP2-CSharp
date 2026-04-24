namespace CP2_CSharp.Models;

public class Paciente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public DateTime DataCadastro { get; set; }

    public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    public ICollection<Prontuario> Prontuarios { get; set; } = new List<Prontuario>();
}
