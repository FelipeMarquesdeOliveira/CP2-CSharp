using Microsoft.AspNetCore.Mvc;
using CP2_CSharp.DTOs;
using CP2_CSharp.Services;

namespace CP2_CSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultasController : ControllerBase
{
    private readonly ConsultaService _service;

    public ConsultasController(ConsultaService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Marcar([FromBody] ConsultaMarcacaoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var consulta = await _service.Marcar(dto);
        return CreatedAtAction(nameof(BuscarPorId), new { id = consulta.Id }, consulta);
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        var consultas = await _service.ListarTodos();
        return Ok(consultas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var consulta = await _service.BuscarPorId(id);
        if (consulta == null)
            return NotFound("Consulta não encontrada");
        return Ok(consulta);
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> AtualizarStatus(int id, [FromBody] string status)
    {
        try
        {
            var consulta = await _service.AtualizarStatus(id, status);
            return Ok(consulta);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Cancelar(int id)
    {
        try
        {
            await _service.Cancelar(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
