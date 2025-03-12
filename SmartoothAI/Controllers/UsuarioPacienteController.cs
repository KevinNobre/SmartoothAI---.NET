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
        [ProducesResponseType(typeof(UsuarioPaciente), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UsuarioPaciente>> GetById(int id)
        {
            var usuarioPaciente = await _usuarioPacienteService.GetByIdAsync(id);
            if (usuarioPaciente == null)
            {
                return NotFound(new { message = "Usuário Paciente não encontrado." });
            }
            return Ok(usuarioPaciente);
        }

        // Get all
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioPaciente>), 200)]
        public async Task<ActionResult<IEnumerable<UsuarioPaciente>>> GetAll()
        {
            var usuariosPacientes = await _usuarioPacienteService.GetAllAsync();
            return Ok(usuariosPacientes);
        }

        // Create
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioPaciente), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UsuarioPaciente>> Create([FromBody] UsuarioPacienteDTO usuarioPacienteDTO)
        {
            if (usuarioPacienteDTO == null)
            {
                return BadRequest(new { message = "Usuário Paciente não pode ser nulo." });
            }

            var usuarioPaciente = await _usuarioPacienteService.CreateAsync(usuarioPacienteDTO);

            return CreatedAtAction(nameof(GetById), new { id = usuarioPaciente.PacienteId }, usuarioPaciente);
        }

        // Update
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioPacienteDTO usuarioPacienteDTO)
        {
            if (usuarioPacienteDTO == null)
            {
                return BadRequest(new { message = "Os dados do usuário paciente são inválidos." });
            }

            if (usuarioPacienteDTO.PacienteId != id)
            {
                return BadRequest(new { message = "O ID do corpo da requisição não corresponde ao ID da URL." });
            }

            var existingPaciente = await _usuarioPacienteService.GetByIdAsync(id);
            if (existingPaciente == null)
            {
                return NotFound(new { message = "Usuário Paciente não encontrado." });
            }

            await _usuarioPacienteService.UpdateAsync(id, usuarioPacienteDTO);
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _usuarioPacienteService.DeleteAsync(id);
            if (!success)
            {
                return NotFound(new { message = "Usuário Paciente não encontrado." });
            }

            return NoContent();
        }
    }
}
