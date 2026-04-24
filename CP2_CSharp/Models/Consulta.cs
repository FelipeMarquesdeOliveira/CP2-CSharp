namespace CP2_CSharp.Models;

public class Consulta
{
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }
    public DateTime DataHora { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Observacoes { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; }

    public Paciente Paciente { get; set; } = null!;
    public Medico Medico { get; set; } = null!;
    public Prontuario? Prontuario { get; set; }
}
