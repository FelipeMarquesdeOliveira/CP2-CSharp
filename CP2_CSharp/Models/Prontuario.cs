namespace CP2_CSharp.Models;

public class Prontuario
{
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public int ConsultaId { get; set; }
    public string Diagnostico { get; set; } = string.Empty;
    public string Prescricao { get; set; } = string.Empty;
    public string Observacoes { get; set; } = string.Empty;
    public DateTime DataProntuario { get; set; }

    public Paciente Paciente { get; set; } = null!;
    public Consulta Consulta { get; set; } = null!;
}
