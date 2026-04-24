using System.ComponentModel.DataAnnotations;

namespace CP2_CSharp.DTOs;

public class ConsultaMarcacaoDto
{
    [Required(ErrorMessage = "PacienteId é obrigatório")]
    public int PacienteId { get; set; }

    [Required(ErrorMessage = "MedicoId é obrigatório")]
    public int MedicoId { get; set; }

    [Required(ErrorMessage = "Data e hora são obrigatórios")]
    [DataFutura(ErrorMessage = "A data da consulta não pode ser no passado")]
    public DateTime DataHora { get; set; }

    public string Observacoes { get; set; } = string.Empty;
}
