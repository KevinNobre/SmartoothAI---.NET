using Microsoft.AspNetCore.Mvc;
using SmartoothAI.Application.Services;
using SmartoothAI.Application.DTOs;
using SmartoothAI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartoothAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioPacienteController : ControllerBase
    {
        private readonly UsuarioPacienteService _usuarioPacienteService;

        public UsuarioPacienteController(UsuarioPacienteService usuarioPacienteService)
        {
            _usuarioPacienteService = usuarioPacienteService;
        }

        // Get by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioPaciente>> GetById(int id)
        {
            var usuarioPaciente = await _usuarioPacienteService.GetByIdAsync(id);
            if (usuarioPaciente == null)
            {
                return NotFound();
            }
            return Ok(usuarioPaciente);
        }

        // Get all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioPaciente>>> GetAll()
        {
            var usuariosPacientes = await _usuarioPacienteService.GetAllAsync();
            return Ok(usuariosPacientes);
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<UsuarioPaciente>> Create([FromBody] UsuarioPacienteDTO usuarioPacienteDTO)
        {
            if (usuarioPacienteDTO == null)
            {
                return BadRequest("Usuário Paciente não pode ser nulo.");
            }

            var usuarioPaciente = await _usuarioPacienteService.CreateAsync(usuarioPacienteDTO);

            return CreatedAtAction(nameof(GetById), new { id = usuarioPaciente.PacienteId }, usuarioPaciente);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UsuarioPacienteDTO usuarioPacienteDTO)
        {
            if (usuarioPacienteDTO == null || usuarioPacienteDTO.PacienteId != id)
            {
                return BadRequest("Dados inválidos.");
            }

            var existingPaciente = await _usuarioPacienteService.GetByIdAsync(id);
            if (existingPaciente == null)
            {
                return NotFound();
            }

            await _usuarioPacienteService.UpdateAsync(id, usuarioPacienteDTO);

            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuarioPaciente = await _usuarioPacienteService.GetByIdAsync(id);
            if (usuarioPaciente == null)
            {
                return NotFound();
            }

            await _usuarioPacienteService.DeleteAsync(id);

            return NoContent();
        }
    }
}
