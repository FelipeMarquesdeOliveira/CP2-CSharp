using Microsoft.AspNetCore.Mvc;
using CP2_CSharp.DTOs;
using CP2_CSharp.Services;

namespace CP2_CSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacientesController : ControllerBase
{
    private readonly PacienteService _service;

    public PacientesController(PacienteService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] PacienteCadastroDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paciente = await _service.Cadastrar(dto);
        return CreatedAtAction(nameof(BuscarPorId), new { id = paciente.Id }, paciente);
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] PacienteAtualizacaoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var paciente = await _service.Atualizar(dto);
            return Ok(paciente);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        var pacientes = await _service.ListarTodos();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var paciente = await _service.BuscarPorId(id);
        if (paciente == null)
            return NotFound("Paciente não encontrado");
        return Ok(paciente);
    }

    [HttpGet("buscar/{nome}")]
    public async Task<IActionResult> BuscarPorNome(string nome)
    {
        var pacientes = await _service.BuscarPorNome(nome);
        return Ok(pacientes);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            await _service.Excluir(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
