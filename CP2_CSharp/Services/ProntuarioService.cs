using Microsoft.EntityFrameworkCore;
using CP2_CSharp.Data;
using CP2_CSharp.DTOs;
using CP2_CSharp.Models;

namespace CP2_CSharp.Services;

public class ProntuarioService
{
    private readonly ClinicDbContext _context;

    public ProntuarioService(ClinicDbContext context)
    {
        _context = context;
    }

    public async Task<ProntuarioVisualizacaoDto?> BuscarPorId(int id)
    {
        var prontuario = await _context.Prontuarios
            .Include(p => p.Paciente)
            .Include(p => p.Consulta)
                .ThenInclude(c => c.Medico)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prontuario == null) return null;

        return new ProntuarioVisualizacaoDto
        {
            Id = prontuario.Id,
            PacienteId = prontuario.PacienteId,
            NomePaciente = prontuario.Paciente.Nome,
            CpfPaciente = prontuario.Paciente.Cpf,
            ConsultaId = prontuario.ConsultaId,
            DataConsulta = prontuario.Consulta.DataHora,
            NomeMedico = prontuario.Consulta.Medico.Nome,
            Especialidade = prontuario.Consulta.Medico.Especialidade,
            Diagnostico = prontuario.Diagnostico,
            Prescricao = prontuario.Prescricao,
            Observacoes = prontuario.Observacoes,
            DataProntuario = prontuario.DataProntuario
        };
    }

    public async Task<List<ProntuarioVisualizacaoDto>> ListarPorPaciente(int pacienteId)
    {
        return await _context.Prontuarios
            .Include(p => p.Paciente)
            .Include(p => p.Consulta)
                .ThenInclude(c => c.Medico)
            .Where(p => p.PacienteId == pacienteId)
            .Select(p => new ProntuarioVisualizacaoDto
            {
                Id = p.Id,
                PacienteId = p.PacienteId,
                NomePaciente = p.Paciente.Nome,
                CpfPaciente = p.Paciente.Cpf,
                ConsultaId = p.ConsultaId,
                DataConsulta = p.Consulta.DataHora,
                NomeMedico = p.Consulta.Medico.Nome,
                Especialidade = p.Consulta.Medico.Especialidade,
                Diagnostico = p.Diagnostico,
                Prescricao = p.Prescricao,
                Observacoes = p.Observacoes,
                DataProntuario = p.DataProntuario
            })
            .ToListAsync();
    }
}
