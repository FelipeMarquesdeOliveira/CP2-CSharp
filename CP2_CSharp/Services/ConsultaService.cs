using Microsoft.EntityFrameworkCore;
using CP2_CSharp.Data;
using CP2_CSharp.DTOs;
using CP2_CSharp.Models;

namespace CP2_CSharp.Services;

public class ConsultaService
{
    private readonly ClinicDbContext _context;

    public ConsultaService(ClinicDbContext context)
    {
        _context = context;
    }

    public async Task<Consulta> Marcar(ConsultaMarcacaoDto dto)
    {
        var consulta = new Consulta
        {
            PacienteId = dto.PacienteId,
            MedicoId = dto.MedicoId,
            DataHora = dto.DataHora,
            Status = "Agendada",
            Observacoes = dto.Observacoes,
            DataCadastro = DateTime.Now
        };

        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();
        return consulta;
    }

    public async Task<List<Consulta>> ListarTodos()
    {
        return await _context.Consultas
            .Include(c => c.Paciente)
            .Include(c => c.Medico)
            .ToListAsync();
    }

    public async Task<Consulta?> BuscarPorId(int id)
    {
        return await _context.Consultas
            .Include(c => c.Paciente)
            .Include(c => c.Medico)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Consulta> AtualizarStatus(int id, string status)
    {
        var consulta = await _context.Consultas.FindAsync(id)
            ?? throw new InvalidOperationException("Consulta não encontrada");

        consulta.Status = status;
        await _context.SaveChangesAsync();
        return consulta;
    }

    public async Task Cancelar(int id)
    {
        await AtualizarStatus(id, "Cancelada");
    }
}
