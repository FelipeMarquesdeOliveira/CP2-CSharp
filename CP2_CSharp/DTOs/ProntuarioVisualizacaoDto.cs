namespace CP2_CSharp.DTOs;

public class ProntuarioVisualizacaoDto
{
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public string NomePaciente { get; set; } = string.Empty;
    public string CpfPaciente { get; set; } = string.Empty;
    public int ConsultaId { get; set; }
    public DateTime DataConsulta { get; set; }
    public string NomeMedico { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;
    public string Diagnostico { get; set; } = string.Empty;
    public string Prescricao { get; set; } = string.Empty;
    public string Observacoes { get; set; } = string.Empty;
    public DateTime DataProntuario { get; set; }
}
