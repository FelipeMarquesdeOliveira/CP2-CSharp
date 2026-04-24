using Microsoft.EntityFrameworkCore;
using CP2_CSharp.Data;
using CP2_CSharp.DTOs;
using CP2_CSharp.Models;

namespace CP2_CSharp.Services;

public class PacienteService
{
    private readonly ClinicDbContext _context;

    public PacienteService(ClinicDbContext context)
    {
        _context = context;
    }

    public async Task<Paciente> Cadastrar(PacienteCadastroDto dto)
    {
        var paciente = new Paciente
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Email = dto.Email,
            Telefone = dto.Telefone,
            DataNascimento = dto.DataNascimento,
            DataCadastro = DateTime.Now
        };

        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();
        return paciente;
    }

    public async Task<Paciente> Atualizar(PacienteAtualizacaoDto dto)
    {
        var paciente = await _context.Pacientes.FindAsync(dto.Id)
            ?? throw new InvalidOperationException("Paciente não encontrado");

        paciente.Nome = dto.Nome;
        paciente.Cpf = dto.Cpf;
        paciente.Email = dto.Email;
        paciente.Telefone = dto.Telefone;
        paciente.DataNascimento = dto.DataNascimento;

        await _context.SaveChangesAsync();
        return paciente;
    }

    public async Task<List<Paciente>> ListarTodos()
    {
        return await _context.Pacientes.ToListAsync();
    }

    public async Task<Paciente?> BuscarPorId(int id)
    {
        return await _context.Pacientes.FindAsync(id);
    }

    public async Task<List<Paciente>> BuscarPorNome(string nome)
    {
        return await _context.Pacientes
            .Where(p => p.Nome.Contains(nome))
            .ToListAsync();
    }

    public async Task Excluir(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id)
            ?? throw new InvalidOperationException("Paciente não encontrado");

        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();
    }
}
