using Microsoft.AspNetCore.Mvc;
using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Application.DTOs;

namespace SmartoothAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioPacienteController : ControllerBase
    {
        private readonly IUsuarioPacienteRepository _usuarioPacienteRepository;

        public UsuarioPacienteController(IUsuarioPacienteRepository usuarioPacienteRepository)
        {
            _usuarioPacienteRepository = usuarioPacienteRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioPaciente>> GetById(int id)
        {
            var usuarioPaciente = await _usuarioPacienteRepository.GetByIdAsync(id);
            if (usuarioPaciente == null)
            {
                return NotFound();
            }
            return Ok(usuarioPaciente);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioPaciente>>> GetAll()
        {
            var usuariosPacientes = await _usuarioPacienteRepository.GetAllAsync();
            return Ok(usuariosPacientes);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioPaciente>> Create([FromBody] UsuarioPacienteDTO usuarioPacienteDTO)
        {
            if (usuarioPacienteDTO == null)
            {
                return BadRequest("Usuário Paciente não pode ser nulo.");
            }

            var usuarioPaciente = new UsuarioPaciente
            {
                Nome = usuarioPacienteDTO.Nome,
                Email = usuarioPacienteDTO.Email
            };

            await _usuarioPacienteRepository.AddAsync(usuarioPaciente);

            return CreatedAtAction(nameof(GetById), new { id = usuarioPaciente.PacienteId }, usuarioPaciente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UsuarioPaciente usuarioPaciente)
        {
            if (usuarioPaciente == null || usuarioPaciente.PacienteId != id)
            {
                return BadRequest("Dados inválidos.");
            }

            var existingPaciente = await _usuarioPacienteRepository.GetByIdAsync(id);
            if (existingPaciente == null)
            {
                return NotFound();
            }

            await _usuarioPacienteRepository.UpdateAsync(usuarioPaciente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuarioPaciente = await _usuarioPacienteRepository.GetByIdAsync(id);
            if (usuarioPaciente == null)
            {
                return NotFound();
            }

            await _usuarioPacienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
