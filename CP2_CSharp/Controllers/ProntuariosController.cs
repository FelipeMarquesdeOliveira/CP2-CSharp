using Microsoft.AspNetCore.Mvc;
using CP2_CSharp.Services;

namespace CP2_CSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProntuariosController : ControllerBase
{
    private readonly ProntuarioService _service;

    public ProntuariosController(ProntuarioService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var prontuario = await _service.BuscarPorId(id);
        if (prontuario == null)
            return NotFound("Prontuário não encontrado");
        return Ok(prontuario);
    }

    [HttpGet("paciente/{pacienteId}")]
    public async Task<IActionResult> ListarPorPaciente(int pacienteId)
    {
        var prontuarios = await _service.ListarPorPaciente(pacienteId);
        return Ok(prontuarios);
    }
}
